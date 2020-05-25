using System;

namespace Virtuality.API.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Topic { get; set; }

        public string Title { get; set; }
        
        public string Subject { get; set; }

        public DateTime AddedOn { get; set; }

        public double Rating { get; set; }

        public bool Varified { get; set; }

        public Teacher Teacher { get; set; }

        public int TeacherId { get; set; }
    }
}