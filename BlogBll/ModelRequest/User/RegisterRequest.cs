using System.ComponentModel.DataAnnotations;

namespace BlogBLL.ModelRequest
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
