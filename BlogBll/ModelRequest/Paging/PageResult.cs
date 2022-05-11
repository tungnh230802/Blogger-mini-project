using System.Collections.Generic;

namespace BlogBLL.ModelRequest
{
    public class PageResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}
