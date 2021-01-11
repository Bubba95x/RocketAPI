using API.RocketStats.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.RocketStats.Models;
using Services.RocketStats.Services;
using System.Threading.Tasks;

namespace API.RocketStats.Controllers
{
    [Route("api/matchstatistic")]
    [Authorize]
    [ApiController]
    public class MatchStatisticsController
    {
        private readonly IMapper mapper;
        private readonly IMatchStatisticService matchStatisticService;

        public MatchStatisticsController(IMapper mapper, IMatchStatisticService matchStatisticService)
        {
            this.mapper = mapper;
            this.matchStatisticService = matchStatisticService;
        }

        [HttpPost("")]
        public async Task<MatchStatisticResponseDto> AddAsync([FromBody] MatchStatisticRequestDto matchStatisticDto)
        {
            var model = mapper.Map<MatchStatisticModel>(matchStatisticDto);
            var response = await matchStatisticService.AddAsync(model);
            return mapper.Map<MatchStatisticResponseDto>(response);
        }
    }
}
