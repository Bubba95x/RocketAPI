using System;

namespace Data.RocketStats.Entities
{
    public class PlayerMatchEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid? MatchID { get; set; }
        public string Victory { get; set; }
        public Guid RocketStatsID { get; set; }
        public string RocketStatsGameMode { get; set; }
        public DateTime RocketStatsMatchDate { get; set; }
    }
}
