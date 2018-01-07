using System;
using System.Collections.Generic;
using NoComment.Domain.Models;

namespace NoComment.Domain.Dtos
{
    public class ForumDto : ForumDisplayDto
    {
        public IEnumerable<EmailDto> Emails { get; set; }
    }
}