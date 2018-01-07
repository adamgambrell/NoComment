using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoComment.Domain.Contracts;
using NoComment.Domain.Dtos;
using NoComment.Domain.Models;

namespace NoComment.Data
{
    public class NoCommentRepository : IRepository
    {
        private NoCommentContext _context;
        public NoCommentRepository(NoCommentContext context)
        {
            _context = context;
        }

        public async Task<bool> EmailIsNew(string messageId)
        {
            return await _context.Emails.FindAsync(messageId).ConfigureAwait(false) == null ? true : false;
        }
        public async Task<bool> ForumIsNew(string rootEmailId)
        {
            return await _context.Forums.FindAsync(rootEmailId).ConfigureAwait(false) == null ? true : false;
        }

        public async Task CreateForum(Forum forum)
        {
            await _context.Forums.AddAsync(forum).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task CreateEmail(Email email)
        {
            await _context.Emails.AddAsync(email).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public IEnumerable<Forum> GetForumList()
        {
            return _context.Forums.OrderByDescending(f => f.CreationDate).Include(f => f.Emails).ToList();
        }

        public IEnumerable<ForumDisplayDto> GetForumDtoList()
        {
            return _context.Forums.OrderByDescending(f => f.CreationDate).Select(f => new ForumDisplayDto {
                CreationDate = f.CreationDate,
                RootEmailId = f.RootEmailId,
                Subject = f.Subject,
                EmailCount = f.Emails.Count
            });
        }

        public async Task<Forum> GetForumById(string rootEmailId)
        {
            return await _context.Forums.Include(f => f.Emails).FirstOrDefaultAsync(f => f.RootEmailId == rootEmailId).ConfigureAwait(false);
        }
    }
}