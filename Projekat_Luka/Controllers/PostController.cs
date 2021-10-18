using InstagramServices.Service;
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
    public class PostController : ControllerBase
    {
        public IPostService _postService;
        

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost("add-posts")]
        public async Task<IActionResult> AddPost([FromBody] PostDto postDto)
        {
            
            await _postService.Add(postDto);
            return Ok();
        }

        [HttpGet("get-all-posts")]
        public async Task<IActionResult> GetAllPosts()
        {
            
            var allPosts = await _postService.GetAll();
            return Ok(allPosts);
        }

        [HttpGet("get-post-by-id/{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await _postService.GetById(id);
            return Ok(post);
        }

         [HttpDelete("delete-post-by-id")]
         public async Task<IActionResult> DeletePost(int id)
         {
             await _postService.Remove(id);
            return Ok(id);

         }

        [HttpPut("edit-post")]
        public async Task<IActionResult> EditPost([FromBody] PostDto postDto)
        {
            await _postService.Edit(postDto);
            return Ok(postDto);

        }
    }
}
