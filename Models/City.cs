using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpTask.Models
{
    public class City
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
    }
}