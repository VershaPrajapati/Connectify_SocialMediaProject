using Connectify_SocialMediaProject.PostMicroservice.BusinessLayer.ModelDto;
using Connectify_SocialMediaProject.PostMicroservice.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Connectify_SocialMediaProject.PostMicroservice.Controller
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPostsAsync()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> GetPostByIdAsync(int id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<PostDto>> CreatePostAsync(PostDto postDto)
        {
            try
            {
                var createdPost = await _postService.CreatePostAsync(postDto);
                return CreatedAtAction(nameof(GetPostByIdAsync), new { id = createdPost.Id }, createdPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PostDto>> UpdatePostAsync(int id, EditPostDto editPostDto)
        {
            try
            {
                var updatedPost = await _postService.UpdatePostAsync(id, editPostDto);
                return Ok(updatedPost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePostAsync(int id)
        {
            try
            {
                var result = await _postService.DeletePostAsync(id);
                if (result)
                    return NoContent();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
