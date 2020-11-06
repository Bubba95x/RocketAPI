using Services.RocketStats.Models;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public interface IMatchStatisticService
    {
        Task AddAsync(MatchStatisticsModel model);
    }
}
