using Connectify_SocialMediaProject.PostMicroservice.BusinessLayer.ModelDto;
using Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Models;
using Connectify_SocialMediaProject.PostMicroservice.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connectify_SocialMediaProject.PostMicroservice.BusinessLayer.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<PostDto>> GetAllPostsAsync()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return MapPostListToPostDtoList(posts);
        }

        public async Task<PostDto> GetPostByIdAsync(int postId)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);
            return MapPostToPostDto(post);
        }

        public async Task<PostDto> CreatePostAsync(PostDto postDto)
        {
            var post = MapPostDtoToPost(postDto);
            post.CreatedAt = DateTime.UtcNow;
            post.UpdatedAt = DateTime.UtcNow;
            var createdPost = await _postRepository.CreatePostAsync(post);
            return MapPostToPostDto(createdPost);
        }

        public async Task<PostDto> UpdatePostAsync(int postId, EditPostDto editPostDto)
        {
            var existingPost = await _postRepository.GetPostByIdAsync(postId);
            if (existingPost == null)
                throw new Exception("Post not found");

            existingPost.Title = editPostDto.Title;
            existingPost.Content = editPostDto.Content;
            existingPost.UpdatedAt = DateTime.UtcNow;

            var updatedPost = await _postRepository.UpdatePostAsync(existingPost);
            return MapPostToPostDto(updatedPost);
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            var existingPost = await _postRepository.GetPostByIdAsync(postId);
            if (existingPost == null)
                throw new Exception("Post not found");

            return await _postRepository.DeletePostAsync(existingPost);
        }

        private PostDto MapPostToPostDto(Post post)
        {
            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                UserId = post.UserId,
            };
        }

        private IEnumerable<PostDto> MapPostListToPostDtoList(IEnumerable<Post> posts)
        {
            var postDtoList = new List<PostDto>();
            foreach (var post in posts)
            {
                postDtoList.Add(MapPostToPostDto(post));
            }
            return postDtoList;
        }

        private Post MapPostDtoToPost(PostDto postDto)
        {
            return new Post
            {
                Title = postDto.Title,
                Content = postDto.Content,
                UserId = postDto.UserId
            };
        }
    }
}
