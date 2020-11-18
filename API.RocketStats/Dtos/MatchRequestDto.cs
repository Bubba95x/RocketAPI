using System;
using System.ComponentModel.DataAnnotations;

namespace API.RocketStats.Dtos
{
    public class MatchRequestDto
    {
        [Required]
        public Guid RocketStatsID { get; set; }
        [Required]
        public string GameMode { get; set; }
        [Required]
        public DateTime MatchDate { get; set; }
    }
}
