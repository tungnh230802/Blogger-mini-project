using System.ComponentModel.DataAnnotations;

namespace BlogBLL.ModelRequest
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public bool Remember { get; set; } = false;
    }
}
