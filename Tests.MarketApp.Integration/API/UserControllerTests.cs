using System.Net;
using System.Net.Http.Json;
using AutoMapper;
using MarketApp.API.Controllers;
using MarketApp.API.Controllers.Responses;
using MarketApp.Business.Interfaces;
using MarketApp.Business.Models;
using MarketApp.Business.Tests.Fakers;
using MarketApp.Business.UnitOfWork;
using MarketApp.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests.MarketApp.Integration.API
{
    public class UserControllerTests : TestWithDb<DataContext>
    {
        private UserControllers _userController;
        private Mock<IUsersServices> _service;
        private Mock<IUnitOfWork> _uow;
        private Mock<IMapper> _mapper;
        private UserDtoFaker _faker;

        public UserControllerTests() {
            _service = new();
            _uow = new();
            _mapper = new();
            _userController = new(_service.Object, _uow.Object, _mapper.Object);
            _faker = new();
        }

        [Fact]
        public async Task CreateAsync_ReturnsOkResult_WhenUserIsValid() {
            var userDto = _faker.NewUser().Generate();
            _service.Setup(service => service.AddUsersAsync(It.IsAny<UserDto>()))
                .Returns((Task<int>)Task.CompletedTask);

            var result = await _userController.CreateAsync(userDto);

            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.IsType<ApiResponse>(okResult.Value);
            var apiResponse = okResult.Value as ApiResponse;
            Assert.NotNull(apiResponse);
            Assert.Equal("Пользователь успешно создан", apiResponse.Message);
        }

        [Fact]
        public async Task CreateAsync_ReturnsUnauthorizedResult_WhenUserIsNotAuthorized() {
            var userDto = new UserDto();
            _userController.ControllerContext = new ControllerContext();

            var result = await _userController.CreateAsync(userDto);

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task CreateAsync_ReturnsBadRequestResult_WhenUserIsInvalid() {

            var userDto = _faker.NewUser().RuleFor(x => x.Name, "asdasdadsa").Generate();

            _userController.ModelState.AddModelError("UserName", "The UserName field is required");
            var result = await _userController.CreateAsync(userDto);

            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            Assert.NotNull(badRequestResult);
        }
    }
}