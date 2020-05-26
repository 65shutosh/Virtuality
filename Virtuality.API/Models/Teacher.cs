namespace Virtuality.API.Models
{
    public class Teacher
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string Address { get; set; }

        public int zip { get; set; }

        public Account Account { get; set; }

        public int AccountId { get; set; }

        public User User { get; set; }       

        public int UserId { get; set; } 
    }
}