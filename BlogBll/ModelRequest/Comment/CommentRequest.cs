using System;

namespace BlogBLL.ModelRequest
{
    public class CommentRequest
    {
        public Guid id { get; set; }
        public Guid? parentId { get; set; }
        public Guid? postId { get; set; }
        public DateTime createAt { get; set; }
        public DateTime? updateAt { get; set; }
        public string content { get; set; }
        public string userId { get; set; }
    }
}
