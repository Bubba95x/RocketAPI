﻿using System;

namespace Services.RocketStats.Models
{
    public class MatchModel : BaseModel
    {
        public Guid ID { get; set; }
        public string GameMode { get; set; }
        public DateTime MatchDate { get; set; }
    }
}
