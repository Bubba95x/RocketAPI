using System;

namespace API.RocketStats.Dtos
{
    public class PlayerMatchResponseDto : PlayerMatchRequestDto
    {
        public Guid ID { get; set; }
    }
}
