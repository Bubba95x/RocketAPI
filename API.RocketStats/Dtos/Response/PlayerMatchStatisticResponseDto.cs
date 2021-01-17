using API.RocketStats.Dtos.Request;
using System;

namespace API.RocketStats.Dtos.Response
{
    public class PlayerMatchStatisticResponseDto : PlayerMatchStatisticRequestDto
    {
        public Guid ID { get; set; }
    }
}
