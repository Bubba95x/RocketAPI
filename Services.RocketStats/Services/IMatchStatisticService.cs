using Services.RocketStats.Models;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public interface IMatchStatisticService
    {
        Task<MatchStatisticModel> AddAsync(MatchStatisticModel model);
    }
}
