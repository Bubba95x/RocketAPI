using AutoMapper;
using Services.RocketStats.Models;
using System;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public class RTConversionService : IRTConversionService
    {
        private readonly IMapper mapper;
        private readonly IMatchService matchService;
        private readonly IMatchStatisticService matchStatisticService;

        public RTConversionService(IMapper mapper, IMatchService matchService, IMatchStatisticService matchStatisticService)
        {
            this.mapper = mapper;
            this.matchService = matchService;
            this.matchStatisticService = matchStatisticService;
        }

        public async Task ProcessMatchAsync(Guid userID, RTMatchModel rtMatchModel)
        {
            var match = mapper.Map<MatchModel>(rtMatchModel);
            var matchReponse = await matchService.AddAsync(match);
            
            var saves = mapper.Map<MatchStatisticsModel>(rtMatchModel.Stats.Saves);
            saves.UserID = userID;
            saves.MatchID = matchReponse.ID;

            var assists = mapper.Map<MatchStatisticsModel>(rtMatchModel.Stats.Assists);
            assists.UserID = userID;
            assists.MatchID = matchReponse.ID;

            var goals = mapper.Map<MatchStatisticsModel>(rtMatchModel.Stats.Goals);
            goals.UserID = userID;
            goals.MatchID = matchReponse.ID;

            var shots = mapper.Map<MatchStatisticsModel>(rtMatchModel.Stats.Shots);
            shots.UserID = userID;
            shots.MatchID = matchReponse.ID;

            await matchStatisticService.AddAsync(saves);
            await matchStatisticService.AddAsync(assists);
            await matchStatisticService.AddAsync(goals);
            await matchStatisticService.AddAsync(shots);
        }
    }
}
