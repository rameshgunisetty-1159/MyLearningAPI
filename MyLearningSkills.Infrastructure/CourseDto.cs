namespace MyLearningSkills.Infrastructure
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public decimal Duration { get; set; }

        public decimal Rating { get; set; }
    }
}
