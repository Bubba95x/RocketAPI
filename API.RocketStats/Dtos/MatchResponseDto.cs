using System;

namespace API.RocketStats.Dtos
{
    public class MatchResponseDto : MatchRequestDto
    {
        public Guid ID { get; set; }
    }
}
