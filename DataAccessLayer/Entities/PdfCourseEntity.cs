using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class PdfCourseEntity
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CourseId { get; set;}
    }
}
