using API.RocketStats.Dtos.Request;
using System;

namespace API.RocketStats.Dtos.Response
{
    public class PlayerMatchResponseDto : PlayerMatchRequestDto
    {
        public Guid ID { get; set; }
    }
}
