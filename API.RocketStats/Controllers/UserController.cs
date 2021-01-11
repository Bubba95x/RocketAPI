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
    [Route("api/user")]
    [ApiController]
    public class UserController
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpPost("")]
        [Authorize("RocketAPI.Write")]
        public async Task<UserResponseDto> AddAsync([FromBody] UserRequestDto userDto)
        {
            var model = mapper.Map<UserModel>(userDto);
            var response = await userService.AddAsync(model);
            return mapper.Map<UserResponseDto>(response);
        }

        [HttpGet("{ID}")]
        [Authorize("RocketAPI.Read")]
        public async Task<UserResponseDto> GetAsync([FromRoute] Guid ID)
        {
            var response = await userService.GetAsync(ID);
            return mapper.Map<UserResponseDto>(response);
        }

        [HttpGet("list")]
        [Authorize("RocketAPI.Read")]
        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            var response = await userService.GetAllAsync();
            return mapper.Map<List<UserResponseDto>>(response);
        }

    }
}
