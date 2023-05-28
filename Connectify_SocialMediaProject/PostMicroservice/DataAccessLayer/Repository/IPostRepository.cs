using Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(int postId);
        Task<Post> CreatePostAsync(Post post);
        Task<Post> UpdatePostAsync(Post post);
        Task<bool> DeletePostAsync(Post post);
    }
}
