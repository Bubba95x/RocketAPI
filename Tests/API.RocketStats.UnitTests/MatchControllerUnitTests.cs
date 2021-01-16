using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Text;
using System.Threading.Tasks;
using Services.RocketStats.Services;
using AutoMapper;
using API.RocketStats.AutoMapper;
using Xunit;
using Bogus;
using API.RocketStats.Dtos;
using API.RocketStats.Controllers;
using Services.RocketStats.Models;

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
        private static bool AreEqualModelAndResponseDto(MatchModel model, MatchResponseDto dto)
        {
            return model.ID == dto.ID
                && model.MatchDate == dto.MatchDate
                && model.GameMode == dto.GameMode;
        }

        private static bool AreEqualRequestAndResponseDto(MatchRequestDto model, MatchResponseDto dto)
        {
            return model.MatchDate == dto.MatchDate
                && model.GameMode == dto.GameMode;
        }

        private static Faker<MatchModel> SetupMatchModelFaker()
        {
            return new Faker<MatchModel>()
                .StrictMode(false) // If enabled you must have a rule for each property
                .RuleFor(o => o.MatchDate, f => f.Date.Past());
        }

        private static Faker<MatchRequestDto> SetupMatchRequestDtoFaker()
        {
            return new Faker<MatchRequestDto>()
                .StrictMode(false) // If enabled you must have a rule for each property
                .RuleFor(o => o.MatchDate, f => f.Date.Past())
                .RuleFor(o => o.GameMode, f => f.Name.FullName());
        }
        #endregion

        [Fact]
        public async Task GetAsync_HappyPath()
        {
            var matchModel = testModelMatches.Generate();
            var requestId = matchModel.ID;
            mockMatchService.Setup(service => service.GetAsync(requestId)).ReturnsAsync(matchModel);

            var response = await matchController.GetAsync(requestId);

            mockMatchService.Verify(service => service.GetAsync(requestId), Times.Once);
            Assert.True(AreEqualModelAndResponseDto(matchModel, response));
        }

        [Fact]
        public async Task AddAsync_HappyPath()
        {
            var matchRequestDto = testRequestDtoMatches.Generate();
            var matchModel = mapper.Map<MatchModel>(matchRequestDto);
            var matchModelResult = mapper.Map<MatchModel>(matchRequestDto);
            var id = Guid.NewGuid();
            matchModelResult.ID = id;
            mockMatchService.Setup(service => service.AddAsync(It.IsAny<MatchModel>())).ReturnsAsync(matchModelResult);

            var response = await matchController.AddAsync(matchRequestDto);

            Assert.True(AreEqualRequestAndResponseDto(matchRequestDto, response));
            Assert.Equal(id, response.ID);
            mockMatchService.Verify(service => service.AddAsync(It.IsAny<MatchModel>()), Times.Once);
        }
    }
}
