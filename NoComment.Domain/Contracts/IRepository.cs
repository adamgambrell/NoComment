using System.Collections.Generic;
using System.Threading.Tasks;
using NoComment.Domain.Dtos;
using NoComment.Domain.Models;

namespace NoComment.Domain.Contracts
{
    public interface IRepository
    {
        Task<bool> EmailIsNew(string messageId);
        Task<bool> ForumIsNew(string rootEmailId);
        Task CreateForum(Forum forum);
        Task CreateEmail(Email email);
        IEnumerable<Forum> GetForumList();
        IEnumerable<ForumDisplayDto> GetForumDtoList();
        Task<Forum> GetForumById(string rootEmailId);
    }
}