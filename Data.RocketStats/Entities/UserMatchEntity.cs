using System;

namespace Data.RocketStats.Entities
{
    public class UserMatchEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid MatchID { get; set; }
        public string Victory { get; set; }
    }
}
