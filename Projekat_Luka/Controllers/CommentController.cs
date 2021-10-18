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
    public class CommentController : ControllerBase
    {
        public ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("add-comment")]
        public async Task<IActionResult> AddComment([FromBody] CommentDto commentDto)
        {
            
            await _commentService.Add(commentDto);
            return Ok();
        }

        [HttpGet("get-all-comments")]
        public async Task<IActionResult> GetAllComments()
        {
            var allComments = await _commentService.GetAll();
            return Ok(allComments);
        }

        [HttpGet("get-comment-by-id/{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _commentService.GetById(id);
            return Ok(comment);
        }

        [HttpDelete("delete-comment-by-id/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.Remove(id);
            return Ok(id);
            
        }

        [HttpPut("edit-comment")]
        public async Task<IActionResult> EditComment([FromBody] CommentDto commentDto)
        {
            await _commentService.Edit(commentDto);
            return Ok(commentDto);

        }
    }
}
