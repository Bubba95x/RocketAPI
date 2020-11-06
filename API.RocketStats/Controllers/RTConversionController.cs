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
    [Route("api/RocketTracker")]
    [Authorize]
    [ApiController]
    public class RTConversionController
    {
        private readonly IMapper mapper;
        private readonly IRTConversionService conversionService;

        public RTConversionController(IMapper mapper, IRTConversionService conversionService)
        {
            this.mapper = mapper;
            this.conversionService = conversionService;
        }

        [HttpPost]
        [Route("match/user/{userID}")]
        public async Task ProcessMatchAsync([FromBody] RTMatchDto matchDto, [FromRoute]Guid userID)
        {
            var matchModel = mapper.Map<RTMatchModel>(matchDto);
            await conversionService.ProcessMatchAsync(userID, matchModel);
        }
    }
}
