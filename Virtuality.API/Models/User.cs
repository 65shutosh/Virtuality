namespace Virtuality.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string email { get; set; }
        
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
}