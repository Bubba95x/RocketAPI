using System;
using System.ComponentModel.DataAnnotations;

namespace API.RocketStats.Dtos.Request
{
    public class PlayerMatchStatisticRequestDto
    {
        [Required]
        public Guid PlayerMatchId { get; set; }
        [Required]
        public string StatType { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
