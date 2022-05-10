using System.ComponentModel.DataAnnotations;

namespace BlogBLL.ModelRequest.Post
{
    public class PostPutRequest
    {
        [Required]
        [StringLength(50)]
        public string title { get; set; }
        [Required]
        public string thumbnail { get; set; }
        [Required]
        public string content { get; set; }
    }
}
