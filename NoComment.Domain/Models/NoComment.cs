using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoComment.Domain.Models
{
    public class NoComment
    {
        [Key]
        public string NoCommentId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("RootEmailId")]
        public virtual Forum Forum { get; set; }
    }
}