using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MedicationAdministrationSystem.Models
{
    public class AddRoutes
    {
        [Required]
        [Display(Name = "Administration methods")]
        public string routeMethods {get;set;}
    }
}