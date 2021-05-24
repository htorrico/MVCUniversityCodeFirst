﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCUniversityCodeFirst.Models
{
    public class MyContext : DbContext
    {
        public MyContext(): base("name= MyContextDB") { }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}