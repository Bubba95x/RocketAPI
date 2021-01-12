using System;

namespace API.RocketStats.Dtos
{
    public class PlayerMatchStatisticResponseDto : PlayerMatchStatisticRequestDto
    {
        public Guid ID { get; set; }
    }
}
