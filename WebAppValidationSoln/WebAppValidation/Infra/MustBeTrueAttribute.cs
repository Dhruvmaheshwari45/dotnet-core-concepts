using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppValidation.Infra
{
    public class MustBeTrueAttribute: ValidationAttribute
    {
        public MustBeTrueAttribute()
        {
            ErrorMessage = "Please Accept the terms";
        }
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
    }
}