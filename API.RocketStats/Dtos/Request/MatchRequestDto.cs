using System;
using System.ComponentModel.DataAnnotations;

namespace API.RocketStats.Dtos.Request
{
    public class MatchRequestDto
    {
        [Required]
        public string GameMode { get; set; }
        [Required]
        public DateTime MatchDate { get; set; }
    }
}