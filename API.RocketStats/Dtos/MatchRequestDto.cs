using System;

namespace API.RocketStats.Dtos
{
    public class MatchRequestDto
    {
        public Guid RocketStatsID { get; set; }
        public string GameMode { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
