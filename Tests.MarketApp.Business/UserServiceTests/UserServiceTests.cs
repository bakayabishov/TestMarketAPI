using AutoMapper;
using FluentAssertions;
using MarketApp.Business.Exceptions;
using MarketApp.Business.Models.Mappings;
using MarketApp.Business.Services;
using MarketApp.Business.Tests.Fakers;
using MarketApp.Business.UnitOfWork;
using MarketApp.DataAccess.Entities;
using Moq;
using NUnit.Framework;

namespace MarketApp.Business.Tests.UserServiceTests;

public class UserServiceTests : TestBase {
    private UsersServices _userServices;
    private Mock<IUnitOfWork> _uow;
    private UserDtoFaker _userDtoFaker;

    public override void Setup() {
        _uow = new();
        _userServices = new(CreateMapper(new UserMappingProfile()), _uow.Object);
        _userDtoFaker = new();
    }

    public override void TearDown() { }
    
    [Test]
    public async Task AddAsync_Should_ThrowException_When_UserWithSameNameAlreadyExistInSystem () {
        _uow.Setup(x => x.Users.IsAlreadyRegisteredAsync(It.IsAny<string>())).ReturnsAsync(true);

        var user = _userDtoFaker.NewUser().Generate();
        var action = async () => await _userServices.AddUsersAsync(user);

        await action.Should().ThrowAsync<UserAlreadyExistException>();
        _uow.Verify(
            x => x.Users.IsAlreadyRegisteredAsync(It.Is<string>(c => !string.IsNullOrEmpty(c))),
            Times.Once);
    }

    [Test]
    public async Task AddUsersAsync_UserDoesNotExist_ShouldInsertUser()
    {
        var user = _userDtoFaker.NewUser().Generate();
        _uow.Setup(uow => uow.Users.IsAlreadyRegisteredAsync(It.IsAny<string>())).ReturnsAsync(false);

        await _userServices.AddUsersAsync(user);

        _uow.Verify(uow => uow.Users.InsertAsync(It.IsAny<User>()), Times.Once);
        _uow.Verify(uow => uow.SaveChangesAsync(), Times.Once);
    }
}