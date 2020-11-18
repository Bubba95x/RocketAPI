using System;

namespace API.RocketStats.Dtos
{
    public class MatchStatisticResponseDto : MatchStatisticRequestDto
    {
        public Guid ID { get; set; }
    }
}
