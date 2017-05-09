using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webCRUD_MVC.Models
{
    public class EmployeeModel
    {
        [Display(Name ="Employee Number")]
        public int EmpId { get; set; }
        [Required(ErrorMessage ="Employee Name Required")]
        public string EmpName { get; set; }
        [Required(ErrorMessage ="Job Title Required")]
        public string jobTitle { get; set; }
    }
}