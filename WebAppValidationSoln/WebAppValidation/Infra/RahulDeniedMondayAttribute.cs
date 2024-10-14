using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppValidation.Models;

namespace WebAppValidation.Infra
{
    public class RahulDeniedMondayAttribute: ValidationAttribute
    {
        public RahulDeniedMondayAttribute()
        {
            ErrorMessage = "Rahul is not available on monday!!!";
        }
        public override bool IsValid(object value)
        {
            Appointment appointment = value as Appointment;
            return appointment == null || !(appointment.DoctorName.ToLower() == "rahul" && appointment.Date.DayOfWeek == DayOfWeek.Monday);
        }
    }
}