﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }

        // Students
        public ICollection<Student> Students { get; set; }
        // Instructors

        // Grade
    }
}