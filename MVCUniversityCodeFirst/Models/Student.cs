using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUniversityCodeFirst.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string LastName { get; set; }


        public string FirstName { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}