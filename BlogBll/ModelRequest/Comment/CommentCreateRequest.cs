using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBLL.ModelRequest.Comment
{
    public class CommentCreateRequest
    {
        public int? parentId { get; set; }
        [Required]
        public int postId { get; set; }
        [Required]
        [MaxLength(1000)]
        public string content { get; set; }
        [Required]
        public string userId { get; set; }
    }
}
