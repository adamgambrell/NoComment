using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NoComment.Domain.Models
{
    public class Author
    {
        [Key]
        public string AuthorId { get; set; }
        public string Password { get; set; }
        public string AuthorEmail { get; set; }
        public string Username { get; set; }
        public string AuthurName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<NoComment> NoCommentIds { get; set; }
    }
}