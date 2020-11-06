using Services.RocketStats.Models;
using System;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public interface IRTConversionService
    {
        Task ProcessMatchAsync(Guid userId, RTMatchModel matchModel);
    }
}
