using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hLib.Models.ValidatonRules
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ISBNValidationAttribute : ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var _value_lenght = value.ToString().Length;

                if(_value_lenght != 17 && _value_lenght != 13)
                {
                    return new ValidationResult("Lenght not proper!");
                }
            }
            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule mvr = new ModelClientValidationRule();
            mvr.ErrorMessage = "ISBN number not valid!";
            mvr.ValidationType = "isbnvalidation";
            return new[] { mvr };
        }
    }
}