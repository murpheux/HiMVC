using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC.Models.Domain
{
    public class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }


        public List<Course> Courses { get; set; }

    }
}
