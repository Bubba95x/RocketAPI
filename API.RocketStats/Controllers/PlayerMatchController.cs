using API.RocketStats.Dtos;
using AutoMapper;
using Services.RocketStats.Models;
using Services.RocketStats.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace API.RocketStats.Controllers
{
    [Route("api/playermatch")]
    [ApiController]
    public class PlayerMatchController
    {
        private readonly IMapper mapper;
        private readonly IPlayerMatchService playerMatchService;

        public PlayerMatchController(IMapper mapper, IPlayerMatchService userMatchService)
        {
            this.mapper = mapper;
            this.playerMatchService = userMatchService;
        }

        [HttpPost("")]
        [Authorize("RocketAPI.Write")]
        public async Task<PlayerMatchResponseDto> AddAsync([FromBody] PlayerMatchRequestDto userMatchDto)
        {
            var model = mapper.Map<PlayerMatchModel>(userMatchDto);
            var response = await playerMatchService.AddAsync(model);
            return mapper.Map<PlayerMatchResponseDto>(response);
        }

        [HttpPut("{ID}")]
        [Authorize("RocketAPI.Write")]
        public async Task<PlayerMatchResponseDto> UpdateAsync([FromRoute] Guid ID, [FromBody] PlayerMatchRequestDto userMatchDto)
        {
            var model = mapper.Map<PlayerMatchModel>(userMatchDto);
            model.ID = ID;
            var response = await playerMatchService.UpdateAsync(model);
            return mapper.Map<PlayerMatchResponseDto>(response);
        }

        [HttpGet("{ID}")]
        [Authorize("RocketAPI.Read")]
        public async Task<PlayerMatchResponseDto> GetAsync([FromRoute] Guid ID)
        {
            var response = await playerMatchService.GetAsync(ID);
            return mapper.Map<PlayerMatchResponseDto>(response);
        }

        [HttpGet("user/{userId}/match/{matchId}")]
        [Authorize("RocketAPI.Read")]
        public async Task<PlayerMatchResponseDto> GetByUserIdAndMatchIdAsync([FromRoute] Guid userId, [FromRoute] Guid matchId)
        {
            var response = await playerMatchService.GetByUserIdAndMatchIdAsync(userId, matchId);
            return mapper.Map<PlayerMatchResponseDto>(response);
        }
    }
}
