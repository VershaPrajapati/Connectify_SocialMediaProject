using Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Data;
using Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly PostDbContext _dbContext;

        public PostRepository(PostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _dbContext.Posts.Include(p => p.UserId).ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int postId)
        {
            return await _dbContext.Posts.Include(p => p.UserId).FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdatePostAsync(Post post)
        {
            _dbContext.Posts.Update(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<bool> DeletePostAsync(Post post)
        {
            _dbContext.Posts.Remove(post);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
