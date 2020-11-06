using System.Collections.Generic;

namespace Services.RocketStats.Models
{
    public class RTMatchProcessedModel
    {
        public MatchModel MatchInfo { get; set; }
        public List<MatchStatisticsModel> MatchStatistics { get; set; }

        public RTMatchProcessedModel()
        {
            MatchInfo = new MatchModel();
            MatchStatistics = new List<MatchStatisticsModel>();
        }
    }
}
