namespace Virtuality.API.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public int Ammount { get; set; }

        public string TransactionMethod { get; set; }

        public string TransactionID { get; set; }

        public bool varified { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }
    }
}