using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BlogDAL.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public DateTime registerAt { get; set; }
        public DateTime? lastLogin { get; set; }
        public string intro { get; set; }
        public string profile { get; set; }
        public ICollection<Post> posts { get; set; }
        public ICollection<Comment> comments { get; set; }
    }
}
