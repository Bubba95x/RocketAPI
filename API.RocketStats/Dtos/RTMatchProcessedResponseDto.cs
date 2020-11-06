using System.Collections.Generic;

namespace API.RocketStats.Dtos
{
    public class RTMatchProcessedResponseDto
    {
        public MatchResponseDto MatchInfo { get; set; }
        public List<MatchStatisticsResponseDto> MatchStatistics { get; set; }
    }
}
