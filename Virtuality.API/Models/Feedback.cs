namespace Virtuality.API.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public double Rate { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }
 
    }
}