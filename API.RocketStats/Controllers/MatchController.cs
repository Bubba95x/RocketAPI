using API.RocketStats.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.RocketStats.Models;
using Services.RocketStats.Services;
using System;
using System.Threading.Tasks;

namespace API.RocketStats.Controllers
{
    [Route("api/match")]
    [ApiController]
    public class MatchController
    {
        private readonly IMapper mapper;
        private readonly IMatchService matchService;

        public MatchController(IMapper mapper, IMatchService matchService)
        {
            this.mapper = mapper;
            this.matchService = matchService;
        }

        [HttpGet("{ID}")]
        [Authorize("RocketAPI.Read")]
        public async Task<MatchResponseDto> GetAsync([FromRoute] Guid ID)
        {
            var response = await matchService.GetAsync(ID);
            return mapper.Map<MatchResponseDto>(response);
        }

        [HttpGet("rocketstatsid/{ID}")]
        [Authorize("RocketAPI.Read")]
        public async Task<MatchResponseDto> GetByRocketStatsIDAsync([FromRoute] Guid ID)
        {
            var response = await matchService.GetByRocketStatsIDAsync(ID);
            return mapper.Map<MatchResponseDto>(response);
        }

        [HttpPost("")]
        [Authorize("RocketAPI.Write")]
        public async Task<MatchResponseDto> AddAsync([FromBody] MatchRequestDto matchDto)
        {
            var model = mapper.Map<MatchModel>(matchDto);
            var response = await matchService.AddAsync(model);
            return mapper.Map<MatchResponseDto>(response);
        }
    }
}
