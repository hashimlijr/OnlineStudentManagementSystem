using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineStudentManagementSystem
{
    public class Profesion
    {
        [Key]
        public int ProfesionId { get; set; }
        [Required]
        public string ProfesionName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}