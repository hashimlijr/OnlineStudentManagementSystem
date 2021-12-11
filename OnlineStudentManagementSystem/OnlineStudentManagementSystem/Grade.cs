using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Grade
    {
        public int GradeID { get; set; }

        // CourseID
        public int CourseID { get; set; }

        // StudentID
        public int StudentID { get; set; }

        public int GradeScore { get; set; }
        
    }
}