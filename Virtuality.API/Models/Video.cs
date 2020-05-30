namespace Virtuality.API.Models
{
    public class Video
    {
        public int Id { get; set; }

        public int SequenceNumber { get; set; }

        public string VideoName { get; set; }

        public string VideoPath { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }
    }
}