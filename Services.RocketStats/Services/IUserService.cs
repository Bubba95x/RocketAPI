using Services.RocketStats.Models;
using System.Threading.Tasks;

namespace Services.RocketStats.Services
{
    public interface IUserService
    {
        Task<UserModel> AddAsync(UserModel model);
    }
}
