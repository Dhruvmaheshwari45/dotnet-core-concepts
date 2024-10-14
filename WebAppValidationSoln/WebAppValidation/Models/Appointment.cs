using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppValidation.Infra;

namespace WebAppValidation.Models
{
    [RahulDeniedMonday]
    public class Appointment
    {
        [Required (ErrorMessage = "Please Enter the name")]
        public string DoctorName { get; set; }
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime Date { get; set; }
        [MustBeTrue]
        public bool TermsAccepted { get; set; }
    }
}