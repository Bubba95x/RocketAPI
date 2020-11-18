using System;

namespace Services.RocketStats.Models
{
    public class MatchStatisticModel
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid MatchID { get; set; }
        public string StatType { get; set; }
        public int Value { get; set; }
    }
}
