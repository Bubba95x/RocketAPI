﻿using API.RocketStats.Dtos;
using AutoMapper;
using Services.RocketStats.Models;
using Services.RocketStats.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.RocketStats.Controllers
{
    [Route("api/usermatch")]
    //[Authorize]
    [ApiController]
    public class UserMatchController
    {
        private readonly IMapper mapper;
        private readonly IUserMatchService userMatchService;

        public UserMatchController(IMapper mapper, IUserMatchService userMatchService)
        {
            this.mapper = mapper;
            this.userMatchService = userMatchService;
        }

        [HttpPost("")]
        public async Task<UserMatchResponseDto> AddAsync([FromBody] UserMatchRequestDto userMatchDto)
        {
            var model = mapper.Map<UserMatchModel>(userMatchDto);
            var response = await userMatchService.AddAsync(model);
            return mapper.Map<UserMatchResponseDto>(response);
        }

        [HttpGet("user/{userId}/match/{matchId}")]
        public async Task<UserMatchResponseDto> GetByUserIdAndMatchIdAsync([FromRoute] Guid userId, [FromRoute] Guid matchId)
        {
            var response = await userMatchService.GetByUserIdAndMatchIdAsync(userId, matchId);
            return mapper.Map<UserMatchResponseDto>(response);
        }
    }
}