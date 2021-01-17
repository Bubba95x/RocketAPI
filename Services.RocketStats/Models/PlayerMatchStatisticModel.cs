using System;

namespace Services.RocketStats.Models
{
    public class PlayerMatchStatisticModel : BaseModel
    {
        public Guid ID { get; set; }
        public Guid PlayerMatchId { get; set; }
        public string StatType { get; set; }
        public int Value { get; set; }
    }
}
