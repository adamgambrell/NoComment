using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoComment.Domain.Models
{
    public class Email
    {
        [Key]
        public string AuthorId { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public virtual ICollection<NoComment> NoComments { get; set; }


        public string MessageId { get; set; }
        public string RootEmailId { get; set; }
        public string InReplyToId { get; set; }
        public DateTime Date { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        
    }
}