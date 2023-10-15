namespace Api_Fondamental.Models
{
    public class PdfCourseViewModel
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CourseId { get; set; }
    }
}
