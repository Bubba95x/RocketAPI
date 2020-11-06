using System;

namespace API.RocketStats.Dtos
{
    public class UserResponseDto : UserRequestDto
    {
        public Guid ID { get; set; }
    }
}
