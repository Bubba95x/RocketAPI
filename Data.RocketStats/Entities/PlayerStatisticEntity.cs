using System;

namespace Data.RocketStats.Entities
{
    public class PlayerStatisticEntity : BaseEntity
    {
        public Guid ID { get; set; }
        public Guid PlayerID { get; set; }
        public string GameMode { get; set; }
        public string StatType { get; set; }
        public int Rank { get; set; }
        public int Percentile { get; set; }
        public int Value { get; set; }
    }
}
