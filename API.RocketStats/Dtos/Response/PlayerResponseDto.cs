using API.RocketStats.Dtos.Request;
using System;

namespace API.RocketStats.Dtos.Response
{
    public class PlayerResponseDto : PlayerRequestDto
    {
        public Guid ID { get; set; }
    }
}
