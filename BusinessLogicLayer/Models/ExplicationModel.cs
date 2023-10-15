using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class ExplicationModel
    {
        public int Id { get; init; }
        public string Content { get; set; }
        public int CourseId { get; set; }
    }
}
