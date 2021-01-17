using API.RocketStats.Dtos.Request;
using System;

namespace API.RocketStats.Dtos.Response
{
    public class MatchResponseDto : MatchRequestDto
    {
        public Guid ID { get; set; }
    }
}
