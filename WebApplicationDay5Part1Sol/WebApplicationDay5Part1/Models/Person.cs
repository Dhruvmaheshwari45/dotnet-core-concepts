using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationDay5Part1.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        public string City { get; set; }

        [Required(ErrorMessage = "Will You attend")]
        public bool? WillAttend { get; set; }
    }
}