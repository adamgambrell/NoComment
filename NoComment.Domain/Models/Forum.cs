using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoComment.Domain.Models
{
    public class Forum
    {
        [Key]
        public string AuthorId { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public virtual ICollection<NoComment> NoComments { get; set; }

        public DateTime CreationDate { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public string RootEmailId { get; set; }
        public string Subject { get; set; }
    }
}