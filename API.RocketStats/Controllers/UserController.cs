using API.RocketStats.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.RocketStats.Models;
using Services.RocketStats.Services;
using System.Threading.Tasks;

namespace API.RocketStats.Controllers
{
    [Route("api/user")]
    [Authorize]
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
        public async Task<UserDto> AddAsync(UserDto userDto)
        {
            var model = mapper.Map<UserModel>(userDto);
            var response = await userService.AddAsync(model);
            return mapper.Map<UserDto>(response);
        }
    }
}
