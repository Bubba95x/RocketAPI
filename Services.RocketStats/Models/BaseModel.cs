using System;

namespace Services.RocketStats.Models
{
    public class BaseModel
    {
        public DateTime DateModifiedUTC { get; set; }
        public DateTime DateCreatedUTC { get; set; }
    }
}
