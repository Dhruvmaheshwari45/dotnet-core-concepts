using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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
            //return appointment == null || !(appointment.DoctorName.ToLower() == "rahul" && appointment.Date.DayOfWeek == DayOfWeek.Monday);

            if(appointment==null && string.IsNullOrEmpty(appointment.DoctorName) && appointment.Date == null)
            {
                return true;
            }else if(appointment.DoctorName.ToLower()=="rahul"  && ((DateTime)appointment.Date).DayOfWeek == DayOfWeek.Monday)
            {
                return false;
            }
            return true;
        }
    }
}