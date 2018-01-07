using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoComment.Domain.Contracts;
using NoComment.Domain.Dtos;
using NoComment.Domain.Models;

namespace NoComment.Web.Controllers
{
    [Route("api/[controller]")]
    public class ForumController : Controller
    {
        private IForumService _forumService;
        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet]
        public async Task<IEnumerable<ForumDisplayDto>> GetForumDtoListAsync()
        {
            var face = await _forumService.GetForumDtoListAsync();
            return face;
        }

        [Route("api/Forum/{rootEmailId}")]
        [HttpGet("{rootEmailId}", Name = "GetByIdRoute")]
        public async Task<ForumDto> GetFromFromId(string rootEmailId)
        {
            return await _forumService.GetForumByIdAsync(rootEmailId);
        }
    }
}