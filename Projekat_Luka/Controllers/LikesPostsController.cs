using InstagramServices.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekat_Luka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesPostsController : ControllerBase
    {
        public ILikesPostsService _likesPostsService;

        public LikesPostsController(ILikesPostsService likesPostsService)
        {
            _likesPostsService = likesPostsService;
        }

        [HttpPost("add-postLike")]
        public IActionResult AddUser([FromBody] LikesPosts like)
        {
            _likesPostsService.Add(like);

            return Ok();
        }

        [HttpGet("get-all-postLikes")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allPostLikes = await _likesPostsService.GetAll();

            return Ok(allPostLikes);
        }
    }
}
