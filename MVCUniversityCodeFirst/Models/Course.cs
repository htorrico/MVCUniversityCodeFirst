using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUniversityCodeFirst.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }

        public int Credits { get; set; }

        //public List<Enrollment> Enrollments { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        

    }
}