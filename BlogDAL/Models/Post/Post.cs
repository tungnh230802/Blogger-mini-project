using System;
using System.Collections.Generic;

namespace BlogDAL.Models
{
    public class Post
    {
        #region Properties
        public Guid id { get; set; }
        public string authorId { get; set; }
        public AppUser userPost { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string summary { get; set; }
        public DateTime createAt { get; set; }
        public DateTime? updateAt { get; set; }
        public string thumbnail { get; set; }
        public string content { get; set; }
        public ICollection<Comment> comments { get; set; }
        #endregion
    }
}
