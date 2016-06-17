using Microsoft.AspNet.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC.ViewModels.Attributes
{
    public class SexAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (StudentModel)validationContext.ObjectInstance;

            if ((student.Sex == "M" ||
                    student.Sex == "F"))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                        "Sex must have a 'M' or 'F'");

        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ClientModelValidationContext context)
        {
            yield return new ModelClientValidationRule("sex",
            "Sex must have a 'M' or 'F'");
        }
    }
}
