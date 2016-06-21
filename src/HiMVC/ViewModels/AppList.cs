using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC.ViewModels
{
    public static class AppList
    {

        public static List<SelectListItem> Countries
        {
            get
            {
                return Controllers.CountryArray.Names.Select((r, index) => new SelectListItem { Text = r, Value = index.ToString() }).ToList();
            }
        }



        //public static List<SelectListItem> Sex = new List<SelectListItem>
        //    {
        //        new SelectListItem { Value = "Male", Text = "Male" },
        //        new SelectListItem { Value = "Female", Text = "Female" },
        //    };

        public static List<SelectListItem> Title = new List<SelectListItem>
            {
                new SelectListItem { Value = "GradAssist", Text = "GradAssist" },
                new SelectListItem { Value = "Dr", Text = "Dr" },
                new SelectListItem { Value = "Prof", Text = "Prof" },
            };
    }
}
