using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBLL.ModelRequest.Comment
{
    public class CommentPutRequest
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public string content { get; set; }
    }
}
