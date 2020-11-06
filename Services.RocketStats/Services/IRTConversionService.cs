using Services.RocketStats.Models;
using System;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public interface IRTConversionService
    {
        Task<RTMatchProcessedModel> ProcessMatchAsync(Guid userID, RTMatchModel rtMatchModel);
    }
}
