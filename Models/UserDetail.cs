using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpTask.Models
{
    public class UserDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]

        [StringLength(50, ErrorMessage = "The  Name must not exceed 50 characters.")]
        [DataType(DataType.Text, ErrorMessage = "Enter Valid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
      
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Number Required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit mobile number.")]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone{ get; set; }


        [StringLength(100, ErrorMessage = "Address must be at most 100 characters long")]
        [Required(ErrorMessage = "Address Feild Required")]

        public string Address{ get; set; }
        public int StateId{ get; set; }
        public int CityId{ get; set; }
      

    }
}