using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.RocketStats.Dtos
{
    public class UserRequestDto
    {
        public string UserName { get; set; }
        public string PlatformName { get; set; }
        public string AvatarUrl { get; set; }
        public string RocketStatsID { get; set; }
    }
}
