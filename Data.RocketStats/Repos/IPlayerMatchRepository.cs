﻿using Data.RocketStats.Entities;
using System;
using System.Threading.Tasks;

namespace Data.RocketStats.Repos
{
    public interface IPlayerMatchRepository
    {
        Task<PlayerMatchEntity> AddAsync(PlayerMatchEntity entity);
        Task<PlayerMatchEntity> UpdateAsync(PlayerMatchEntity entity);
        Task<PlayerMatchEntity> GetAsync(Guid ID);
        Task<PlayerMatchEntity> GetByRocketStatsIDAsync(Guid rocketStatsID);
        Task<PlayerMatchEntity> GetByUserIdAndMatchIdAsync(Guid userId, Guid matchId);
    }
}
