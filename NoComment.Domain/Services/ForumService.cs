using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoComment.Domain.Contracts;
using NoComment.Domain.Dtos;
using NoComment.Domain.Models;

namespace NoComment.Domain.Services
{
    public class ForumService : IForumService
    {
        private IInboxService _inboxService;
        private IRepository _repository;
        public ForumService(IInboxService inboxService, IRepository repository)
        {
            _inboxService = inboxService;
            _repository = repository;
        }
        public async Task<IEnumerable<Forum>> GetForumListAsync()
        {
            await PullNewEmailsFromInbox();
            return _repository.GetForumList();
        }

        

        public async Task<IEnumerable<ForumDisplayDto>> GetForumDtoListAsync()
        {
            await PullNewEmailsFromInbox();
            return _repository.GetForumDtoList();
        }

        public async Task<ForumDto> GetForumByIdAsync(string rootEmailId)
        {
            await PullNewEmailsFromInbox();
            Forum forum = await _repository.GetForumById(rootEmailId).ConfigureAwait(false);
            return new ForumDto {
                CreationDate = forum.CreationDate,
                Emails = forum.Emails.Select(e => new EmailDto {
                    AuthorEmail = e.AuthorEmail,
                    AuthorName = e.AuthorName,
                    Content = e.Content,
                    Date = e.Date,
                    InReplyToId = e.InReplyToId,
                    MessageId = e.MessageId,
                    RootEmailId = e.RootEmailId,
                    Subject = e.Subject
                }).OrderBy(e => e.Date),
                RootEmailId = forum.RootEmailId,
                Subject = forum.Subject
            };
        }

        private async Task PullNewEmailsFromInbox()
        {
            List<Email> emails = (await _inboxService.GetUnreadEmailsAsync().ConfigureAwait(false)).ToList();
            if (emails.Count > 0)
            {
                foreach (Email email in emails)
                {
                    if (await _repository.EmailIsNew(email.MessageId).ConfigureAwait(false))
                    {
                        if (await _repository.ForumIsNew(email.RootEmailId).ConfigureAwait(false))
                        {
                            await _repository.CreateForum(new Forum
                            {
                                CreationDate = email.Date,
                                RootEmailId = email.RootEmailId,
                                Subject = email.Subject
                            }).ConfigureAwait(false);
                        }
                        await _repository.CreateEmail(email).ConfigureAwait(false);
                    }
                }
            }
        }

    }
}