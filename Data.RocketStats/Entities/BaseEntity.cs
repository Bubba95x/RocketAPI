using System;

namespace Data.RocketStats.Entities
{
    public class BaseEntity
    {
        // https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/concurrency?view=aspnetcore-5.0
        // Consider optimistic concurrency - not enough users to be an issue for now but leaving this here for the future if need be
        public DateTime DateModifiedUTC { get; set; } // You will need a base Db Context for these or define it in the Rocket Context directly (leaning latter)
        public DateTime DateCreatedUTC { get; set; }
    }
}
