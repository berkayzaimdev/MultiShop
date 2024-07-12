using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;
using System.ComponentModel.Design;

namespace MultiShop.Comment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = _context.UserComments.AsEnumerable();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var comment = await _context.UserComments.FindAsync(id);
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserComment comment)
        {
            await _context.UserComments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserComment comment)
        {
            _context.UserComments.Update(comment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int commentId)
        {
            var comment = await _context.UserComments.FindAsync(commentId);
            _context.UserComments.Remove(comment!);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
