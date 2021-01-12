using API.RocketStats.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.RocketStats.Models;
using Services.RocketStats.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.RocketStats.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController
    {
        private readonly IMapper mapper;
        private readonly IPlayerService playerService;

        public PlayerController(IMapper mapper, IPlayerService userService)
        {
            this.mapper = mapper;
            this.playerService = userService;
        }

        [HttpPost("")]
        [Authorize("RocketAPI.Write")]
        public async Task<PlayerResponseDto> AddAsync([FromBody] PlayerRequestDto userDto)
        {
            var model = mapper.Map<PlayerModel>(userDto);
            var response = await playerService.AddAsync(model);
            return mapper.Map<PlayerResponseDto>(response);
        }

        [HttpPut("{ID}")]
        [Authorize("RocketAPI.Write")]
        public async Task<PlayerResponseDto> UpdateAsync([FromRoute] Guid ID, [FromBody] PlayerRequestDto userDto)
        {
            // PUTs should match the get https://tools.ietf.org/html/rfc7231#section-4.3.4
            var model = mapper.Map<PlayerModel>(userDto);
            model.ID = ID;
            var response = await playerService.UpdateAsync(model);
            return mapper.Map<PlayerResponseDto>(response);
        }

        [HttpGet("{ID}")]
        [Authorize("RocketAPI.Read")]
        public async Task<PlayerResponseDto> GetAsync([FromRoute] Guid ID)
        {
            var response = await playerService.GetAsync(ID);
            return mapper.Map<PlayerResponseDto>(response);
        }

        [HttpGet("list")]
        [Authorize("RocketAPI.Read")]
        public async Task<List<PlayerResponseDto>> GetAllAsync()
        {
            var response = await playerService.GetAllAsync();
            return mapper.Map<List<PlayerResponseDto>>(response);
        }

    }
}
