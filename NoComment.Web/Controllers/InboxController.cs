using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoComment.Domain.Contracts;

namespace NoComment.Web.Controllers
{
    [Route("api/[controller]")]
    public class InboxController : Controller
    {
        private IInboxService _inboxService;
        public InboxController(IInboxService inboxService)
        {
            _inboxService = inboxService;
        }

        [HttpGet]
        public async Task<string> ResetEmailsAsync()
        {
            await _inboxService.MarkAllEmailsAsUnseenAsync();
            return "value";
        }
    }
}