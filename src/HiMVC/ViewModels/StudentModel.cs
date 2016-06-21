using HiMVC.ViewModels.Attributes;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC.ViewModels
{
    public class StudentModel
    {
        private const int currentYear = 2016; // bad: will not work well in  2017+

        [Key]
        public int StudentId { get; set; }

        [Display(Name ="First Name"), DataType(DataType.Text)]
        [Required, StringLength(60, MinimumLength = 3)]
        [MinLength(5), MaxLength(60)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string FName { get; set; }


        [Display(Name = "Last Name"), DataType(DataType.Text)]
        [Required, StringLength(60, MinimumLength = 3)]
        [MinLength(5), MaxLength(60)]
        public string LName { get; set; }

        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        [Range(0, 100)]
        //[DataType(DataType.Currency)]
        public int Age { get; set; }

        [Range(0.0, 5.0)]
        public float GPA { get; set; }

        //[Display(Name ="Year of Birth"), YearRhyme, Range(1900, currentYear)]
        //public int YearOfBirth { get; set; }

        [Display(Name ="Title")]
        public string LecturerTitle { get; set; }

        public string Lecturer { get; set; }

        [Sex, Required]
        //[MinLength(4), MaxLength(6)]
        public string Sex { get; set; }

        [EmailAddress, Display(Name ="Email")]
        public string Email { get; set; }

        [EmailAddress, Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Emails mismatch")]
        public string ConfirmEmail { get; set; }

        public string Nationality { get; set; }

    }

}
