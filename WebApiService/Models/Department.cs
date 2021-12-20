using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiService.Models
{
    public class Department
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        //[JsonIgnore]
        public virtual HashSet<Employee> Employees { get; set; }
    }
}