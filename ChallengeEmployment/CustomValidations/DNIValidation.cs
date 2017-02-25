using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ChallengeEmployment.CustomValidations
{
    public class DNIValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            var dni = Convert.ToString(value);

            if (String.IsNullOrEmpty(dni))
            {
                return true;
            }

            if (!Regex.IsMatch(value.ToString(), "^(([A-Z]\\d{8})|(\\d{8}[A-Z]))$"))
            {
                return false;
            }

            return true;
        }
    }
}