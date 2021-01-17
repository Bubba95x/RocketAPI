using System.ComponentModel.DataAnnotations;

namespace API.RocketStats.Dtos.Request
{
    public class PlayerRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PlatformName { get; set; }
        public string AvatarUrl { get; set; }
        [Required]
        public string RocketStatsID { get; set; }
    }
}
