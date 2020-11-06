using System;

namespace API.RocketStats.Dtos
{
    public class UserDto
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string PlatformName { get; set; }
        public string PlatformUserID { get; set; }
        public string AvatarUrl { get; set; }
        public string RocketStatsID { get; set; }
    }
}
