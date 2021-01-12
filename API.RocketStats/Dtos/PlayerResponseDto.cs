using System;

namespace API.RocketStats.Dtos
{
    public class PlayerResponseDto : PlayerRequestDto
    {
        public Guid ID { get; set; }
    }
}
