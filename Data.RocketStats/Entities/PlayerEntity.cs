using System;

namespace Data.RocketStats.Entities
{
    public class PlayerEntity
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string PlatformName { get; set; }
        public string AvatarUrl { get; set; }
        public string RocketStatsID { get; set; }

    }
}
