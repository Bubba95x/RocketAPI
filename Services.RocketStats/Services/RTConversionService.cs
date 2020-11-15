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
        private readonly IUserService userService;
        private readonly IUserMatchService userMatchService;

        public RTConversionService(
            IMapper mapper, 
            IMatchService matchService, 
            IMatchStatisticService matchStatisticService, 
            IUserService userService, 
            IUserMatchService userMatchService)
        {
            this.mapper = mapper;
            this.matchService = matchService;
            this.matchStatisticService = matchStatisticService;
            this.userService = userService;
            this.userMatchService = userMatchService;
        }

        public async Task<RTMatchProcessedModel> ProcessMatchAsync(Guid userID, RTMatchModel rtMatchModel)
        {
            var requestMatch = mapper.Map<MatchModel>(rtMatchModel);
            var user = await userService.GetAsync(userID);
            
            if(user == null) // 400 Bad Request
            {
                return null;
            }

            // Create Match
            MatchModel matchResponse = await matchService.GetByRocketStatsIDAsync(requestMatch.ID);            
            if(matchResponse == null)
            {
                matchResponse = await matchService.AddAsync(requestMatch);
            }

            // Create UserMatch Relationship
            var userMatch = new UserMatchModel() { 
                UserID = userID, 
                MatchID = matchResponse.ID, 
                Victory = rtMatchModel.Metadata.Result 
            };
            await userMatchService.AddAsync(userMatch);

            // Create Stats
            var saves = mapper.Map<MatchStatisticsModel>(rtMatchModel.Stats.Saves);
            saves.UserID = userID;
            saves.MatchID = matchResponse.ID;

            var assists = mapper.Map<MatchStatisticsModel>(rtMatchModel.Stats.Assists);
            assists.UserID = userID;
            assists.MatchID = matchResponse.ID;

            var goals = mapper.Map<MatchStatisticsModel>(rtMatchModel.Stats.Goals);
            goals.UserID = userID;
            goals.MatchID = matchResponse.ID;

            var shots = mapper.Map<MatchStatisticsModel>(rtMatchModel.Stats.Shots);
            shots.UserID = userID;
            shots.MatchID = matchResponse.ID;

            var rtResponseModel = new RTMatchProcessedModel() {
                MatchInfo = matchResponse,
            };

            rtResponseModel.MatchStatistics.Add(await matchStatisticService.AddAsync(saves));
            rtResponseModel.MatchStatistics.Add(await matchStatisticService.AddAsync(assists));
            rtResponseModel.MatchStatistics.Add(await matchStatisticService.AddAsync(goals));
            rtResponseModel.MatchStatistics.Add(await matchStatisticService.AddAsync(shots));

            return rtResponseModel;
        }
    }
}
