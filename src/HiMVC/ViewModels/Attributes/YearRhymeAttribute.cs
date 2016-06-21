using Microsoft.AspNet.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC.ViewModels
{
    public class YearRhymeAttribute : ValidationAttribute, IClientModelValidator
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var student = (StudentModel)validationContext.ObjectInstance;
            //int yearOfBirth = student.YearOfBirth;

            //if ((DateTime.Now.Year - yearOfBirth) != student.Age)
            //    return new ValidationResult(
            //            "Year of birth must ryhme with 'Age' provided");

            return ValidationResult.Success;

        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
        {
            yield return new ModelClientValidationRule("yearofbirth",
            "Year of birth must ryhme with 'Age' provided");
        }
    }
}
