using API.RocketStats.AutoMapper;
using API.RocketStats.Controllers;
using API.RocketStats.Dtos.Request;
using API.RocketStats.Dtos.Response;
using AutoMapper;
using Bogus;
using Moq;
using Services.RocketStats.Models;
using Services.RocketStats.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace API.RocketStats.UnitTests
{
    public class PlayerControllerUnitTests
    {
        private readonly Mock<IPlayerService> mockPlayerService;
        private readonly IMapper mapper = new AutoMapperConfiguration().MapperConfiguration.CreateMapper();
        private readonly Faker<PlayerModel> playerModelFaker;
        private readonly Faker<PlayerRequestDto> playerRequestDtoFaker;
        private readonly PlayerController playerController;

        public PlayerControllerUnitTests()
        {
            mockPlayerService = new Mock<IPlayerService>();
            playerModelFaker = SetUpPlayerModelFaker();
            playerRequestDtoFaker = SetUpPlaterRequestDtoFaker();

            playerController = new PlayerController(mapper, mockPlayerService.Object);
        }

        #region Helpers
        private static Faker<PlayerModel> SetUpPlayerModelFaker()
        {
            return new Faker<PlayerModel>()
                .StrictMode(false)
                .RuleFor(o => o.PlatformName, f => f.Name.FirstName())
                .RuleFor(o => o.UserName, f => f.Name.FirstName())
                .RuleFor(o => o.RocketStatsID, f => f.Name.FirstName())
                .RuleFor(o => o.AvatarUrl, f => f.Internet.DomainName())
                .RuleFor(o => o.DateCreatedUTC, f => f.Date.Past())
                .RuleFor(o => o.DateModifiedUTC, f => f.Date.Past());
        }

        public static Faker<PlayerRequestDto> SetUpPlaterRequestDtoFaker()
        {
            return new Faker<PlayerRequestDto>()
                .RuleFor(o => o.PlatformName, f => f.Name.FirstName())
                .RuleFor(o => o.UserName, f => f.Name.FirstName())
                .RuleFor(o => o.RocketStatsID, f => f.Name.FirstName())
                .RuleFor(o => o.AvatarUrl, f => f.Internet.DomainName());
        }

        public static bool AreEqualModelAndResponseDto(PlayerModel model, PlayerResponseDto dto)
        {
            return model.ID == dto.ID
                && model.PlatformName == dto.PlatformName
                && model.RocketStatsID == dto.RocketStatsID
                && model.UserName == dto.UserName
                && model.DateModifiedUTC == dto.DateModifiedUTC
                && model.DateCreatedUTC == dto.DateCreatedUTC;
        }

        private static bool AreEqualRequestAndResponseDto(PlayerRequestDto request, PlayerResponseDto response)
        {
            return request.AvatarUrl == response.AvatarUrl
                && request.PlatformName == response.PlatformName
                && request.RocketStatsID == response.RocketStatsID
                && request.UserName == response.UserName;
        }
        #endregion

        [Fact]
        public async Task AddAsync_HappyPath()
        {
            // Arrange
            var request = playerRequestDtoFaker.Generate();
            var playerModelResponse = mapper.Map<PlayerModel>(request);
            var id = Guid.NewGuid();
            var utcNow = DateTime.UtcNow;
            playerModelResponse.ID = id;
            playerModelResponse.DateCreatedUTC = utcNow;
            playerModelResponse.DateModifiedUTC = utcNow;
            mockPlayerService.Setup(service => service.AddAsync(It.IsAny<PlayerModel>())).ReturnsAsync(playerModelResponse);

            // Act
            var response = await playerController.AddAsync(request);

            // Assert
            Assert.True(AreEqualRequestAndResponseDto(request, response));
            Assert.Equal(id, response.ID);
            Assert.Equal(utcNow, response.DateCreatedUTC);
            Assert.Equal(utcNow, response.DateModifiedUTC);
            mockPlayerService.Verify(service => service.AddAsync(It.IsAny<PlayerModel>()), Times.Once);
        }

        [Fact]
        public async Task GetAsync_HappyPath()
        {
            // Arrange
            var playerModel = playerModelFaker.Generate();
            var id = Guid.NewGuid();
            mockPlayerService.Setup(service => service.GetAsync(id)).ReturnsAsync(playerModel);

            // Act
            var response = await playerController.GetAsync(id);

            // Assert
            Assert.True(AreEqualModelAndResponseDto(playerModel, response));
            mockPlayerService.Verify(service => service.GetAsync(id), Times.Once);
        }

        [Fact]
        public async Task GetAllAsync_HappyPath()
        {
            // Arrange
            int totalPlayers = 5;
            var models = playerModelFaker.Generate(totalPlayers);
            mockPlayerService.Setup(service => service.GetAllAsync()).ReturnsAsync(models);

            // Act
            var response = await playerController.GetAllAsync();

            // Assert
            Assert.Equal(totalPlayers, response.Count);
            mockPlayerService.Verify(service => service.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task PutAsync_HappyPath()
        {
            // Arrange
            var request = playerRequestDtoFaker.Generate();
            var playerModelResponse = mapper.Map<PlayerModel>(request);
            var id = Guid.NewGuid();
            var utcNow = DateTime.UtcNow;
            playerModelResponse.ID = id;
            playerModelResponse.DateCreatedUTC = utcNow;
            playerModelResponse.DateModifiedUTC = utcNow;
            mockPlayerService.Setup(service => service.UpdateAsync(It.IsAny<PlayerModel>())).ReturnsAsync(playerModelResponse);

            // Act
            var response = await playerController.UpdateAsync(id, request);

            // Assert
            Assert.True(AreEqualRequestAndResponseDto(request, response));
            Assert.Equal(id, response.ID);
            Assert.Equal(utcNow, response.DateCreatedUTC);
            Assert.Equal(utcNow, response.DateModifiedUTC);
            mockPlayerService.Verify(service => service.UpdateAsync(It.IsAny<PlayerModel>()), Times.Once);
        }
    }
}
