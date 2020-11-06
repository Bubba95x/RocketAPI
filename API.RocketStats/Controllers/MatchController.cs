using API.RocketStats.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.RocketStats.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.RocketStats.Controllers
{
    [Route("api/match")]
    [Authorize]
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

        [HttpGet("")]
        public async Task<MatchRequestDto> GetAsync(Guid ID)
        {
            var response = await matchService.GetAsync(ID);
            return mapper.Map<MatchRequestDto>(response);
        }
    }
}
