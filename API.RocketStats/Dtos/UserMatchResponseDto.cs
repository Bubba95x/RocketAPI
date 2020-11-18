using System;

namespace API.RocketStats.Dtos
{
    public class UserMatchResponseDto : UserMatchRequestDto
    {
        public Guid ID { get; set; }
    }
}
