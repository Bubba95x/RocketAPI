using System;
using System.ComponentModel.DataAnnotations;

namespace API.RocketStats.Dtos.Request
{
    public class PlayerMatchRequestDto
    {
        [Required]
        public Guid PlayerID { get; set; }
        public Guid? MatchID { get; set; }
        [Required]
        public string Victory { get; set; }
        [Required]
        public Guid RocketStatsID { get; set; }
        [Required]
        public string RocketStatsGameMode { get; set; }
        [Required]
        public DateTime RocketStatsMatchDate { get; set; }
    }
}
