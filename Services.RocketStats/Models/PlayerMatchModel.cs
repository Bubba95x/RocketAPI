using System;

namespace Services.RocketStats.Models
{
    public class PlayerMatchModel : BaseModel
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
