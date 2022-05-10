using System;

namespace BlogBLL.ModelRequest
{
    public class CommentRequest
    {
        public int id { get; set; }
        public int? parentId { get; set; }
        public int? postId { get; set; }
        public DateTime createAt { get; set; }
        public DateTime? updateAt { get; set; }
        public string content { get; set; }
        public string userId { get; set; }
    }
}
