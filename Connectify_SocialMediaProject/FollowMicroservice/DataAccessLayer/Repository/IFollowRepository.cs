using FollowMicroservice.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FollowMicroservice.DataAccessLayer.Repository
{
    public interface IFollowRepository
    {
        Task<IEnumerable<Follow>> GetFollowersAsync(int userId);
        Task<IEnumerable<Follow>> GetFollowingAsync(int userId);
        Task<bool> IsFollowingAsync(int followerId, int followingId);
        Task<Follow> AddFollowAsync(int followerId, int followingId);
        Task<bool> DeleteFollowAsync(int followerId, int followingId);
    }
}
