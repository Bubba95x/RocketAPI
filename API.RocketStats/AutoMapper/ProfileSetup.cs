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
            CreateMap<PlayerMatchStatisticRequestDto, PlayerMatchStatisticModel>()
                .ForMember(dest => dest.ID, op => op.Ignore());
            CreateMap<PlayerMatchRequestDto, PlayerMatchModel>()
                .ForMember(dest => dest.ID, op => op.Ignore());
            CreateMap<PlayerRequestDto, PlayerModel>()
                .ForMember(dest => dest.ID, op => op.Ignore());

            // Model to Dto
            CreateMap<MatchModel, MatchResponseDto>();
            CreateMap<PlayerMatchStatisticModel, PlayerMatchStatisticResponseDto>();
            CreateMap<PlayerMatchModel, PlayerMatchResponseDto>();
            CreateMap<PlayerModel, PlayerResponseDto>();

            // Model - Entity            
            CreateMap<MatchModel, MatchEntity>().ReverseMap();
            CreateMap<PlayerMatchStatisticModel, PlayerMatchStatisticEntity>().ReverseMap();
            CreateMap<PlayerMatchEntity, PlayerMatchModel>().ReverseMap();
            CreateMap<PlayerModel, PlayerEntity>().ReverseMap();
        }
    }
}
