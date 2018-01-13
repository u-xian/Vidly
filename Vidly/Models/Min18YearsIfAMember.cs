using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MemberShipType.Unkown || customer.MembershipTypeId == MemberShipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.birthdate == null)
                return new ValidationResult("BirthDate is required");
            var age = DateTime.Now.Year - customer.birthdate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membesrship");
        }
    }
}