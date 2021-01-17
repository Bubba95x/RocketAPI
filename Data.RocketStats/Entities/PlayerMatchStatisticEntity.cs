using System;

namespace Data.RocketStats.Entities
{
    public class PlayerMatchStatisticEntity : BaseEntity
    {
        public Guid ID { get; set; }
        public Guid PlayerMatchId { get; set; }
        public string StatType { get; set; }
        public int Value { get; set; }
    }
}
