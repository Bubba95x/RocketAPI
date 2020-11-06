using System;

namespace Services.RocketStats.Models
{
    public class UserModel
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string PlatformName { get; set; }
        public string AvatarUrl { get; set; }
        public string RocketStatsID { get; set; }
    }
}
