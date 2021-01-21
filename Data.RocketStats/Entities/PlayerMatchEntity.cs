using System;

namespace Data.RocketStats.Entities
{
    public class PlayerMatchEntity : BaseEntity
    {
        public Guid ID { get; set; }
        public Guid PlayerID { get; set; }
        public Guid? MatchID { get; set; }
        public string Victory { get; set; }
        public Guid RocketStatsID { get; set; }
        public string RocketStatsGameMode { get; set; }
        public DateTime RocketStatsMatchDate { get; set; }
    }
}
