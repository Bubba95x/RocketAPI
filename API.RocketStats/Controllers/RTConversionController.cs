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
        public async Task<RTMatchProcessedResponseDto> ProcessMatchAsync([FromBody] RTMatchRequestDto matchDto, [FromRoute]Guid userID)
        {
            var matchModel = mapper.Map<RTMatchModel>(matchDto);
            var response = await conversionService.ProcessMatchAsync(userID, matchModel);
            return mapper.Map<RTMatchProcessedResponseDto>(response);
        }
    }
}
