using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.RocketStats.Dtos
{
    public class RTMatchDto
    {
        public Guid ID { get; set; }
        public RTMetaDataDto Metadata { get; set; }
        public RTStatsDto Stats { get; set; }

    }
}
