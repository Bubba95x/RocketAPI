using Services.RocketStats.Models;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public interface IPlayerMatchStatisticService
    {
        Task<PlayerMatchStatisticModel> AddAsync(PlayerMatchStatisticModel model);
    }
}
