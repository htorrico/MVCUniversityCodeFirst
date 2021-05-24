using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCUniversityCodeFirst.Models
{
    public class EnrollmentCustom
    {
        public int EnrollmentId { get; set; }
        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string LastName { get; set; }

    }
}