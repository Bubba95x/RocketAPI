﻿using System;

namespace API.RocketStats.Dtos.Response
{
    public class BaseResponseDto
    {
        public DateTime DateModifiedUTC { get; set; }
        public DateTime DateCreatedUTC { get; set; }
    }
}
