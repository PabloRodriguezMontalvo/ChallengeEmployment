using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ChallengeEmployment.CustomValidations
{
    public class TwitterValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var cuenta = Convert.ToString(value);
            if (String.IsNullOrEmpty(cuenta))
            {
                return true;
            }
            if (!cuenta.StartsWith("@"))
            {
                return false;
            }

            return true;
        }

    }
}