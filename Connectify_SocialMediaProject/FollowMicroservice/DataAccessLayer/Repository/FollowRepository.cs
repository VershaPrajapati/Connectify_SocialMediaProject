using FollowMicroservice.DataAccessLayer.Data;
using FollowMicroservice.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FollowMicroservice.DataAccessLayer.Repository
{
    public class FollowRepository : IFollowRepository
    {
        private readonly FollowDbContext _dbContext;

        public FollowRepository(FollowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Follow>> GetFollowersAsync(int userId)
        {
            return await _dbContext.Follows
                .Include(f => f.FollowerId)
                .Where(f => f.FollowingId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Follow>> GetFollowingAsync(int userId)
        {
            return await _dbContext.Follows
                .Include(f => f.FollowingId)
                .Where(f => f.FollowerId == userId)
                .ToListAsync();
        }

        public async Task<bool> IsFollowingAsync(int followerId, int followingId)
        {
            return await _dbContext.Follows
                .AnyAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);
        }

        public async Task<Follow> AddFollowAsync(int followerId, int followingId)
        {
            var follow = new Follow
            {
                FollowerId = followerId,
                FollowingId = followingId
            };

            _dbContext.Follows.Add(follow);
            await _dbContext.SaveChangesAsync();
            return follow;
        }

        public async Task<bool> DeleteFollowAsync(int followerId, int followingId)
        {
            var follow = await _dbContext.Follows
                .SingleOrDefaultAsync(f => f.FollowerId == followerId && f.FollowingId == followingId);

            if (follow == null)
                return false;

            _dbContext.Follows.Remove(follow);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
