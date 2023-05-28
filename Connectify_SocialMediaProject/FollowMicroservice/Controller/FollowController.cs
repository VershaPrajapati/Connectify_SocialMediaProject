using FollowMicroservice.BusinessLayer.ModelDto;
using FollowMicroservice.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FollowMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        [HttpPost("follow")]
        public async Task<IActionResult> FollowUserAsync(FollowDto followDto)
        {
            try
            {
                bool result = await _followService.FollowUserAsync(followDto);
                if (result)
                    return Ok("User followed successfully.");
                else
                    return BadRequest("Unable to follow user.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("unfollow")]
        public async Task<IActionResult> UnfollowUserAsync(FollowDto followDto)
        {
            try
            {
                bool result = await _followService.UnfollowUserAsync(followDto);
                if (result)
                    return Ok("User unfollowed successfully.");
                else
                    return BadRequest("Unable to unfollow user.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("followers/{userId}")]
        public async Task<IActionResult> GetFollowersAsync(int userId)
        {
            try
            {
                var followers = await _followService.GetFollowersAsync(userId);
                return Ok(followers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("following/{userId}")]
        public async Task<IActionResult> GetFollowingAsync(int userId)
        {
            try
            {
                var following = await _followService.GetFollowingAsync(userId);
                return Ok(following);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("isfollowing/{followerId}/{followingId}")]
        public async Task<IActionResult> IsFollowingAsync(int followerId, int followingId)
        {
            try
            {
                bool result = await _followService.IsFollowingAsync(followerId, followingId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
