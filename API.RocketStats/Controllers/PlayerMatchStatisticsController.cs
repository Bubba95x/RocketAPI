using API.RocketStats.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.RocketStats.Models;
using Services.RocketStats.Services;
using System.Threading.Tasks;

namespace API.RocketStats.Controllers
{
    [Route("api/playermatchstatistic")]
    [ApiController]
    public class PlayerMatchStatisticsController
    {
        private readonly IMapper mapper;
        private readonly IPlayerMatchStatisticService matchStatisticService;

        public PlayerMatchStatisticsController(IMapper mapper, IPlayerMatchStatisticService matchStatisticService)
        {
            this.mapper = mapper;
            this.matchStatisticService = matchStatisticService;
        }

        [HttpPost("")]
        [Authorize("RocketAPI.Write")]
        public async Task<PlayerMatchStatisticResponseDto> AddAsync([FromBody] PlayerMatchStatisticRequestDto matchStatisticDto)
        {
            var model = mapper.Map<PlayerMatchStatisticModel>(matchStatisticDto);
            var response = await matchStatisticService.AddAsync(model);
            return mapper.Map<PlayerMatchStatisticResponseDto>(response);
        }
    }
}
