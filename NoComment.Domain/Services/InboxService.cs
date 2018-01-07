using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using NoComment.Domain.Contracts;
using NoComment.Domain.Models;

namespace NoComment.Domain.Services
{
    public class InboxService : IInboxService
    {
        // private readonly IEmailConfiguration _emailConfiguration;
        public InboxService(IEmailConfiguration emailConfiguration)
        {
            // _emailConfiguration = emailConfiguration;
        }

        // public async Task<IEnumerable<Email>> GetUnreadEmailsAsync()
        // {
        //     using (var client = new ImapClient())
        //     {
        //         await SetupClientAsync(client);
        //         var inbox = client.Inbox;
        //         await inbox.OpenAsync(FolderAccess.ReadWrite).ConfigureAwait(false);

        //         List<Email> emails = new List<Email>();
        //         foreach (var uid in inbox.Search(SearchQuery.NotSeen))
        //         {
        //             var message = await inbox.GetMessageAsync(uid).ConfigureAwait(false);
        //             var from = (MailboxAddress)message.From.FirstOrDefault();
        //             emails.Add(new Email
        //             {
        //                 MessageId = message.MessageId,
        //                 RootEmailId = message.References.FirstOrDefault() == null ? message.MessageId : message.References.FirstOrDefault(),
        //                 InReplyToId = message.InReplyTo,
        //                 Date = message.Date.DateTime,
        //                 AuthorEmail = from.Address,
        //                 AuthorName =  from.Name,
        //                 Subject = message.Subject,
        //                 Content = message.TextBody,
        //             });
        //             await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true).ConfigureAwait(false);
        //         }

        //         await inbox.CloseAsync().ConfigureAwait(false);
        //         await client.DisconnectAsync(true).ConfigureAwait(false);
        //         return emails;
        //     }
        // }

        // public async Task MarkAllEmailsAsUnseenAsync()
        // {
        //     using (var client = new ImapClient())
        //     {
        //         await SetupClientAsync(client);
        //         var inbox = client.Inbox;
        //         await inbox.OpenAsync(FolderAccess.ReadWrite).ConfigureAwait(false);

        //         foreach(var uid in inbox.Search(SearchQuery.All))
        //         {
        //             await inbox.RemoveFlagsAsync(uid, MessageFlags.Seen, true).ConfigureAwait(false);
        //         }
        //         await inbox.CloseAsync().ConfigureAwait(false);
        //         await client.DisconnectAsync(true).ConfigureAwait(false);
        //     }
        // }

        // private async Task SetupClientAsync(ImapClient client)
        // {
        //     client.ServerCertificateValidationCallback = (s, c, h, e) => true;
        //     await client.ConnectAsync(_emailConfiguration.ImapServer, _emailConfiguration.ImapPort, true).ConfigureAwait(false);
        //     client.AuthenticationMechanisms.Remove("XOAUTH2");
        //     client.AuthenticationMechanisms.Remove ("NTLM");
        //     await client.AuthenticateAsync(_emailConfiguration.Username, _emailConfiguration.Password).ConfigureAwait(false);
        // }
    }
}