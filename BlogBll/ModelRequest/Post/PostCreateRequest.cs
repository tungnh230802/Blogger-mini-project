using System.ComponentModel.DataAnnotations;

namespace BlogBLL.ModelRequest
{
    public class PostCreateRequest
    {
        [Required]
        public string authorId { get; set; }
        [Required]
        [StringLength(50)]
        public string title { get; set; }
        [Required]
        public string thumbnail { get; set; }
        [Required]
        public string content { get; set; }
    }
}
