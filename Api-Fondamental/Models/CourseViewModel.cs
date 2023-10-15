namespace Api_Fondamental.Models
{
    public class CourseViewModel
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FormationId { get; set; }
    }
}
