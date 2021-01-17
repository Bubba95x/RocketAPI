using API.RocketStats.Dtos.Request;
using API.RocketStats.Dtos.Response;
using AutoMapper;
using Data.RocketStats.Entities;
using Services.RocketStats.Models;

namespace API.RocketStats.AutoMapper
{
    public class ProfileSetup : Profile
    {
        public ProfileSetup()
        {
            // Request Dto to Model
            CreateMap<MatchRequestDto, MatchModel>()
                .ForMember(dest => dest.ID, op => op.Ignore())
                .ForMember(dest => dest.DateModifiedUTC, op => op.Ignore())
                .ForMember(dest => dest.DateCreatedUTC, op => op.Ignore());
            CreateMap<PlayerMatchStatisticRequestDto, PlayerMatchStatisticModel>()
                .ForMember(dest => dest.ID, op => op.Ignore())
                .ForMember(dest => dest.DateModifiedUTC, op => op.Ignore())
                .ForMember(dest => dest.DateCreatedUTC, op => op.Ignore());
            CreateMap<PlayerMatchRequestDto, PlayerMatchModel>()
                .ForMember(dest => dest.ID, op => op.Ignore())
                .ForMember(dest => dest.DateModifiedUTC, op => op.Ignore())
                .ForMember(dest => dest.DateCreatedUTC, op => op.Ignore());
            CreateMap<PlayerRequestDto, PlayerModel>()
                .ForMember(dest => dest.ID, op => op.Ignore())
                .ForMember(dest => dest.DateModifiedUTC, op => op.Ignore())
                .ForMember(dest => dest.DateCreatedUTC, op => op.Ignore());

            // Model to Response Dto
            CreateMap<BaseModel, BaseResponseDto>();
            CreateMap<MatchModel, MatchResponseDto>();
            CreateMap<PlayerMatchStatisticModel, PlayerMatchStatisticResponseDto>();
            CreateMap<PlayerMatchModel, PlayerMatchResponseDto>();
            CreateMap<PlayerModel, PlayerResponseDto>();

            // Model - Entity
            CreateMap<BaseModel, BaseEntity>().ReverseMap();
            CreateMap<MatchModel, MatchEntity>().ReverseMap();
            CreateMap<PlayerMatchStatisticModel, PlayerMatchStatisticEntity>().ReverseMap();
            CreateMap<PlayerMatchEntity, PlayerMatchModel>().ReverseMap();
            CreateMap<PlayerModel, PlayerEntity>().ReverseMap();
        }
    }
}
