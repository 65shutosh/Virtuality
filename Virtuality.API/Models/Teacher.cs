namespace Virtuality.API.Models
{
    public class Teacher
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string address { get; set; }

        public int zip { get; set; }

        public Account Acoount { get; set; }

        public User User { get; set; }       

        public int UserId { get; set; } 
    }
}