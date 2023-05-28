using FollowMicroservice.BusinessLayer.ModelDto;
using FollowMicroservice.DataAccessLayer.Models;
using FollowMicroservice.DataAccessLayer.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FollowMicroservice.BusinessLayer.Services
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;

        public FollowService(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }

        public async Task<bool> FollowUserAsync(FollowDto followDto)
        {
            await _followRepository.AddFollowAsync(followDto.FollowerId, followDto.FollowingId);
            return true;
        }

        public async Task<bool> UnfollowUserAsync(FollowDto followDto)
        {
            var result = await _followRepository.DeleteFollowAsync(followDto.FollowerId, followDto.FollowingId);
            return result;
        }

        public async Task<IEnumerable<Follow>> GetFollowersAsync(int userId)
        {
            return await _followRepository.GetFollowersAsync(userId);
        }

        public async Task<IEnumerable<Follow>> GetFollowingAsync(int userId)
        {
            return await _followRepository.GetFollowingAsync(userId);
        }

        public async Task<bool> IsFollowingAsync(int followerId, int followingId)
        {
            return await _followRepository.IsFollowingAsync(followerId, followingId);
        }
    }
}
