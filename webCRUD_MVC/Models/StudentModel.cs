using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webCRUD_MVC.Models
{
    public class StudentModel
    {
        [Display(Name ="Student Id")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Full Name required"), Display(Name ="Student Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="City required!")]
        public string City { get; set; }
        [Required(ErrorMessage ="Address is Required")]
        public string Address { get; set; }
    }
}