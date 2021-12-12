using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public string BranchName { get; set; }

        public ICollection<Instructor> Instructors { get; set; }
    }
}