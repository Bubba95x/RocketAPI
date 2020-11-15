using AutoMapper;
using Services.RocketStats.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.RocketStats.Controllers
{
    public class UserMatchController
    {
        private readonly IMapper mapper;
        private readonly IUserMatchService userMatchService;

        public UserMatchController(IMapper mapper, IUserMatchService userMatchService)
        {
            this.mapper = mapper;
            this.userMatchService = userMatchService;
        }
    }
}
