using System;

namespace Data.RocketStats.Entities
{
    public class UserStatisticsEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string GameMode { get; set; }
        public string StatType { get; set; }
        public int Rank { get; set; }
        public int Percentile { get; set; }
        public int Value { get; set; }
    }
}
