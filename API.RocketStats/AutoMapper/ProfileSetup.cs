using API.RocketStats.Dtos;
using AutoMapper;
using Data.RocketStats.Entities;
using Services.RocketStats.Models;

namespace API.RocketStats.AutoMapper
{
    public class ProfileSetup : Profile
    {
        public ProfileSetup()
        {
            // Dto to Model
            CreateMap<MatchRequestDto, MatchModel>()
                .ForMember(dest => dest.ID, op => op.Ignore());
            CreateMap<MatchStatisticRequestDto, MatchStatisticModel>()
                .ForMember(dest => dest.ID, op => op.Ignore());
            CreateMap<UserMatchRequestDto, UserMatchModel>()
                .ForMember(dest => dest.ID, op => op.Ignore());
            CreateMap<UserRequestDto, UserModel>()
                .ForMember(dest => dest.ID, op => op.Ignore());

            // Model to Dto
            CreateMap<MatchModel, MatchResponseDto>();
            CreateMap<MatchStatisticModel, MatchStatisticResponseDto>();
            CreateMap<UserMatchModel, UserMatchResponseDto>();
            CreateMap<UserModel, UserResponseDto>();

            // Model - Entity            
            CreateMap<MatchModel, MatchEntity>().ReverseMap();
            CreateMap<MatchStatisticModel, MatchStatisticsEntity>().ReverseMap();
            CreateMap<UserMatchEntity, UserMatchModel>().ReverseMap();
            CreateMap<UserModel, UserEntity>().ReverseMap();
        }
    }
}
