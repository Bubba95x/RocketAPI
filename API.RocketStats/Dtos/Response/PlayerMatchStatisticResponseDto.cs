using API.RocketStats.Dtos.Request;
using System;

namespace API.RocketStats.Dtos.Response
{
    public class PlayerMatchStatisticResponseDto : BaseResponseDto
    {
        public Guid ID { get; set; }
        public Guid PlayerMatchId { get; set; }
        public string StatType { get; set; }
        public int Value { get; set; }
    }
}
