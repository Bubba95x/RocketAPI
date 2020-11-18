using System;
using System.ComponentModel.DataAnnotations;

namespace API.RocketStats.Dtos
{
    public class UserMatchRequestDto
    {
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public Guid MatchID { get; set; }
        [Required]
        public string Victory { get; set; }
    }
}
