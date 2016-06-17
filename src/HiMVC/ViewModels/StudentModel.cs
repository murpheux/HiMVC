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

        [Display(Name ="Name"), DataType(DataType.Text)]
        [Required, StringLength(60, MinimumLength = 3)]
        [MinLength(5), MaxLength(60)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string NewName { get; set; }

        [Range(0, 100)]
        //[DataType(DataType.Currency)]
        public int Age { get; set; }

        [Display(Name ="Year of Birth"), YearRhyme, Range(1900, currentYear)]
        public int YearOfBirth { get; set; }

        [Sex, Required]
        [MinLength(1), MaxLength(1)]
        public string Sex { get; set; }

        [EmailAddress, Display(Name ="Email Address")]
        public string Email { get; set; }

        [EmailAddress, Display(Name = "Confirm Email")]
        [Compare("Email", ErrorMessage = "Emails mismatch")]
        public string ConfirmEmail { get; set; }

        //public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        //{
        //    new SelectListItem { Value = "MX", Text = "Mexico" },
        //    new SelectListItem { Value = "CA", Text = "Canada" },
        //    new SelectListItem { Value = "US", Text = "USA"  },
        //};
    }

    public enum CountryEnum
    {
        [Display(Name = "United Mexican States")]
        Mexico,
        [Display(Name = "United States of America")]
        USA,
        Canada,
        France,
        Germany,
        Spain
    }
}
