using System;

namespace BlogBLL.ModelRequest
{
    public class UserRequest
    {
        public string Id { get; set; }
        public string UserName { get; set; }    
        public string Email { get; set; }
        public string PhoneNumber { get;set; }
        public DateTime registerAt { get; set; }
        public string intro { get; set; }
        public string profile { get; set; }
    }
}
