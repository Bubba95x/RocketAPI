using System;

namespace Services.RocketStats.Models
{
    public class UserMatchModel
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid MatchID { get; set; }
        public string Victory { get; set; }
    }
}
