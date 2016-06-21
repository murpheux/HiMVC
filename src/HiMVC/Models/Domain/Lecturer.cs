using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//using static System.Console;

namespace HiMVC.Models.Domain
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public partial class Lecturer //: Lector, Ilect, IlectMore
    {
        public Lecturer() {}

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LecturerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public EdTitle Title { get; set; }

        public int Rating { get; set; }

        public Course Course { get; set; }

        public string Abbreviated
        {
            get { return $"{Title} {LastName}"; }
        }

    }

    public enum EdTitle
    {
        Dr,
        Prof
    }
}
