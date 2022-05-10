using System;

namespace BlogBLL.ModelRequest
{
    public class PostRequest
    {
        public int id { get; set; }
        public string authorId { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string summary { get; set; }
        public DateTime createAt { get; set; }
        public string thumbnail { get; set; }
        public string content { get; set; }
    }
}
