using Connectify_SocialMediaProject.PostMicroservice.BusinessLayer.ModelDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connectify_SocialMediaProject.PostMicroservice.BusinessLayer.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDto>> GetAllPostsAsync();
        Task<PostDto> GetPostByIdAsync(int postId);
        Task<PostDto> CreatePostAsync(PostDto postDto);
        Task<PostDto> UpdatePostAsync(int postId, EditPostDto editPostDto);
        Task<bool> DeletePostAsync(int postId);
    }
}
