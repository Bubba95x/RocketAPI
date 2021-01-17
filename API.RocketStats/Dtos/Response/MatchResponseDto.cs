using API.RocketStats.Dtos.Request;
using System;

namespace API.RocketStats.Dtos.Response
{
    public class MatchResponseDto : BaseResponseDto
    {
        public Guid ID { get; set; }
        public string GameMode { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
