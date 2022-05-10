namespace BlogBLL.ModelRequest
{
    public class UpdateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string intro { get; set; }
        public string profile { get; set; }
    }
}
