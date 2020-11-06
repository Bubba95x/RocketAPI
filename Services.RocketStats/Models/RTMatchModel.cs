using System;

namespace Services.RocketStats.Models
{
    public class RTMatchModel
    {
        public Guid ID { get; set; }
        public RTMetaDataModel Metadata { get; set; }
        public RTStatsModel Stats { get; set; }
    }
}
