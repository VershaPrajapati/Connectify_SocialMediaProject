using FollowMicroservice.BusinessLayer.ModelDto;
using FollowMicroservice.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FollowMicroservice.BusinessLayer.Services
{
    public interface IFollowService
    {
        Task<bool> FollowUserAsync(FollowDto followDto);
        Task<bool> UnfollowUserAsync(FollowDto followDto);
        Task<IEnumerable<Follow>> GetFollowersAsync(int userId);
        Task<IEnumerable<Follow>> GetFollowingAsync(int userId);
        Task<bool> IsFollowingAsync(int followerId, int followingId);
    }
}
