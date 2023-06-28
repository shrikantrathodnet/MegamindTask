using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmpTask.Models
{
    public class UserDetail
    {
        public int Id { get; set; }

       // [Required(ErrorMessage ="Name Required")]
        
       // [StringLength(50, ErrorMessage = "The  Name must not exceed 50 characters.")]
       //[DataType(DataType.Text,ErrorMessage ="Enter Valid Name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Mobile Number Required")]
        //[RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit mobile number.")]
        //[Display(Name = "Mobile Number")]
        public string Email { get; set; }


        
        //[Required(ErrorMessage ="Age Required")]
        //[Range(1, 110, ErrorMessage = "Age must be between 1 and 110")]
       
        public string Phone{ get; set; }


        //[StringLength(100, ErrorMessage = "Address must be at most 100 characters long")]
        //[Required(ErrorMessage ="Address Feild Required")]

        public string Address{ get; set; }
        public int StateId{ get; set; }
        public int CityId{ get; set; }
        //public State state{ get; set; }
        //public City city{ get; set; }

    }
}