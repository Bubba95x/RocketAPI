﻿using System;

namespace Data.RocketStats.Entities
{
    public class MatchEntity
    {
        public Guid ID { get; set; }
        public string GameMode { get; set; }
        public DateTime MatchDate {get; set;}
    }
}
