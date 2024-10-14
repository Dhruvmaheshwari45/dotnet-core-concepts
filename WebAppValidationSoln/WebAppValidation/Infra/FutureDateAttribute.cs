using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppValidation.Infra
{
    public class FutureDateAttribute: RequiredAttribute
    {
        public FutureDateAttribute()
        {
            ErrorMessage = "Please Enter the future date";
        }
        public override bool IsValid(object value)
        {
            //return base.IsValid(value) && value != null && (DateTime)value > DateTime.Now;

            return base.IsValid(value) && value is DateTime && (DateTime)value > DateTime.Now;
        }
    }
}