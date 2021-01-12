using System;
using System.ComponentModel.DataAnnotations;

namespace API.RocketStats.Dtos
{
    public class PlayerMatchStatisticRequestDto
    {
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public Guid MatchID { get; set; }
        [Required]
        public string StatType { get; set; }
        [Required]
        public int Value { get; set; }
    }
}
