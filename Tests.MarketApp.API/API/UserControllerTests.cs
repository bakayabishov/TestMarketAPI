using AutoMapper;
using FluentAssertions;
using MarketApp.API.Controllers;
using MarketApp.API.Controllers.Responses;
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models;
using MarketApp.Business.Models.Mappings;
using MarketApp.Business.Tests.Fakers;
using MarketApp.Business.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace MarketApp.API.Tests.API;

public class UserControllerTests : TestBase {
    private UserControllers _userControllers;
    private Mock<IUsersServices> _service;
    private Mock<IUnitOfWork> _uow;
    private UserDtoFaker _faker;  

    public override void Setup() {
        _service = new();
        _uow = new();
        _userControllers = new(_service.Object, _uow.Object, CreateMapper(new UserMappingProfile()));

        _faker = new();
    }

    public override void TearDown() { }

    [Test]
    public async Task AddUserAsync_Should_ReturnOkResponse_When_UserCreated()
    {
        var newUser = _faker.NewUser().Generate();
        _service.Setup(x => x.AddUsersAsync(It.IsAny<UserDto>()));
        
        var actual = await _userControllers.CreateAsync(newUser);
        
        actual.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().NotBeNull()
            .And.BeOfType<ApiResponse>()
            .Which.Should().Match<ApiResponse>(x =>
                x.Message.Equals("Пользователь успешно создан"));

    }

    
}