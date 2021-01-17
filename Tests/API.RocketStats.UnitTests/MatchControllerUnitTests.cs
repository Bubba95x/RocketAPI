using System;
using Moq;
using System.Threading.Tasks;
using Services.RocketStats.Services;
using AutoMapper;
using API.RocketStats.AutoMapper;
using Xunit;
using Bogus;
using API.RocketStats.Controllers;
using Services.RocketStats.Models;
using API.RocketStats.Dtos.Response;
using API.RocketStats.Dtos.Request;

namespace API.RocketStats.UnitTests
{
    public class MatchControllerUnitTests
    {
        private readonly Mock<IMatchService> mockMatchService;
        private readonly IMapper mapper = new AutoMapperConfiguration().MapperConfiguration.CreateMapper();
        private readonly Faker<MatchModel> testModelMatches;
        private readonly Faker<MatchRequestDto> testRequestDtoMatches;
        private readonly MatchController matchController;

        public MatchControllerUnitTests()
        {
            mockMatchService = new Mock<IMatchService>();
            testModelMatches = SetupMatchModelFaker();
            testRequestDtoMatches = SetupMatchRequestDtoFaker();

            matchController = new MatchController(mapper, mockMatchService.Object);
        }

        #region Helpers
        private static Faker<MatchModel> SetupMatchModelFaker()
        {
            return new Faker<MatchModel>()
                .StrictMode(false) // If enabled you must have a rule for each property
                .RuleFor(o => o.MatchDate, f => f.Date.Past())
                .RuleFor(o => o.GameMode, f => f.Name.FullName())
                .RuleFor(o => o.DateCreatedUTC, f => f.Date.Past())
                .RuleFor(o => o.DateModifiedUTC, f => f.Date.Past());
        }

        private static Faker<MatchRequestDto> SetupMatchRequestDtoFaker()
        {
            return new Faker<MatchRequestDto>()
                .StrictMode(false) // If enabled you must have a rule for each property
                .RuleFor(o => o.MatchDate, f => f.Date.Past())
                .RuleFor(o => o.GameMode, f => f.Name.FullName());
        }

        private static bool AreEqualModelAndResponseDto(MatchModel model, MatchResponseDto dto)
        {
            return model.ID == dto.ID
                && model.MatchDate == dto.MatchDate
                && model.GameMode == dto.GameMode
                && model.DateCreatedUTC == dto.DateCreatedUTC
                && model.DateModifiedUTC == dto.DateModifiedUTC;
        }

        private static bool AreEqualRequestAndResponseDto(MatchRequestDto request, MatchResponseDto response)
        {
            return request.MatchDate == response.MatchDate
                && request.GameMode == response.GameMode;
        }

        
        #endregion

        [Fact]
        public async Task GetAsync_HappyPath()
        {
            // Arrange
            var matchModel = testModelMatches.Generate();
            var requestId = matchModel.ID;
            mockMatchService.Setup(service => service.GetAsync(requestId)).ReturnsAsync(matchModel);

            // Act
            var response = await matchController.GetAsync(requestId);

            // Assert
            mockMatchService.Verify(service => service.GetAsync(requestId), Times.Once);
            Assert.True(AreEqualModelAndResponseDto(matchModel, response));
        }

        [Fact]
        public async Task AddAsync_HappyPath()
        {
            // Arrange
            var matchRequestDto = testRequestDtoMatches.Generate();
            var matchModelResult = mapper.Map<MatchModel>(matchRequestDto);
            var id = Guid.NewGuid();
            var utcNow = DateTime.UtcNow;
            matchModelResult.ID = id;
            matchModelResult.DateCreatedUTC = utcNow;
            matchModelResult.DateModifiedUTC = utcNow;
            mockMatchService.Setup(service => service.AddAsync(It.IsAny<MatchModel>())).ReturnsAsync(matchModelResult);

            // Act
            var response = await matchController.AddAsync(matchRequestDto);

            // Assert
            Assert.True(AreEqualRequestAndResponseDto(matchRequestDto, response));
            Assert.Equal(id, response.ID);
            Assert.Equal(utcNow, response.DateCreatedUTC);
            Assert.Equal(utcNow, response.DateModifiedUTC);
            mockMatchService.Verify(service => service.AddAsync(It.IsAny<MatchModel>()), Times.Once);
        }
    }
}
