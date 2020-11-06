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
            CreateMap<RTMatchRequestDto, RTMatchModel>();
            CreateMap<RTMetaDataDto, RTMetaDataModel>();
            CreateMap<RTMatchStatsDto, RTMatchStatsModel>();
            CreateMap<RTMetaDataDto, RTMetaDataModel>();
            CreateMap<RTStatsDto, RTStatsModel>();
            CreateMap<UserRequestDto, UserModel>()
                .ForMember(dest => dest.ID, op => op.Ignore());
            CreateMap<MatchRequestDto, MatchModel>()
                .ForMember(dest => dest.ID, op => op.Ignore());

            // Model to Entity
            CreateMap<MatchStatisticsModel, MatchStatisticsEntity>();
            CreateMap<MatchModel, MatchEntity>();
            CreateMap<UserModel, UserEntity>()
                .ForMember(dest => dest.ID, op => op.Ignore());

            // -------------------
            // Entity to Model
            CreateMap<MatchEntity, MatchModel>();
            CreateMap<UserEntity, UserModel>();
            CreateMap<MatchStatisticsEntity, MatchStatisticsModel>();

            // Model to Dto
            CreateMap<UserModel, UserResponseDto>();
            CreateMap<MatchModel, MatchResponseDto>();
            CreateMap<MatchStatisticsModel, MatchStatisticsResponseDto>();
            CreateMap<RTMatchProcessedModel, RTMatchProcessedResponseDto>();

            // -------------------
            // Model to Model
            CreateMap<RTMatchModel, MatchModel>()
                .ForMember(dest => dest.RocketStatsID, op => op.MapFrom(src => src.ID))
                .ForMember(dest => dest.MatchDate, op => op.MapFrom(src => src.Metadata.DateCollected))
                .ForMember(dest => dest.GameMode, op => op.MapFrom(src => src.Metadata.Playlist))
                .ForMember(dest => dest.ID, op => op.Ignore());

            CreateMap<RTMatchStatsModel, MatchStatisticsModel>()
                .ForMember(dest => dest.Value, op => op.MapFrom(src => src.Value))
                .ForMember(dest => dest.StatType, op => op.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.MatchID, op => op.Ignore())
                .ForMember(dest => dest.UserID, op => op.Ignore())
                .ForMember(dest => dest.ID, op => op.Ignore());
        }
    }
}
