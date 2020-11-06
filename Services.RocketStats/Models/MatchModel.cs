using System;

namespace Services.RocketStats.Models
{
    public class MatchModel
    {
        public Guid ID { get; set; }
        public Guid RocketStatsID { get; set; }
        public string GameMode { get; set; }
        public DateTime MatchDate {get; set;}
    }
}
