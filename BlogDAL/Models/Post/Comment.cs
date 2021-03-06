using System;
using System.Collections.Generic;

namespace BlogDAL.Models
{
    public class Comment
    {
        #region Properties
        public Guid id { get; set; }
        public Guid? parentId { get; set; }
        public Guid? postId { get; set; }
        public string content { get; set; }
        public Guid userId { get; set; }
        public Post post { get; set; }
        public Comment comment { get; set; }
        public ICollection<Comment> comments { get; set; }
        public DateTime createAt { get; set; }
        public DateTime? updateAt { get; set; }
        public AppUser userComment { get; set; }
        #endregion
    }
}
