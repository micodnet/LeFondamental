using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class CourseModel
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FormationId { get; set; }
    }
}
