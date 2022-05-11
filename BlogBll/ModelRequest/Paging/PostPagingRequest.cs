using System;
using System.Collections.Generic;

namespace BlogBLL.ModelRequest.Post
{
    public class PostPagingRequest : PagingRequestBase
    {
        public string keywork { get; set; }
        public List<Guid> authorIds { get; set; }
    }
}
