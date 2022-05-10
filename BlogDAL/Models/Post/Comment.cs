using System;
using System.Collections.Generic;

namespace BlogDAL.Models
{
    public class Comment
    {
        #region Properties
        public int id { get; set; }
        public int? parentId { get; set; }
        public int? postId { get; set; }
        public string content { get; set; }
        public string userId { get; set; }
        public Post post { get; set; }
        public Comment comment { get; set; }
        public ICollection<Comment> comments { get; set; }
        public DateTime createAt { get; set; }
        public DateTime? updateAt { get; set; }
        public User userComment { get; set; }
        #endregion
    }
}
