using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApiService.Models
{
    public class Employee
    {
        [Key]
        [Column(Order = 0)]

        public int Id { get; set; }
        [Column(Order = 1)]

        public string Name { get; set; }
        [Column(Order = 2)]

        public int Age { get; set; }
        [Column(Order = 3)]

        public int Salary { get; set; }
        [Column(Order = 4)]

        [ForeignKey("Department")]
        public int Deptid { get; set; }
        //[JsonIgnore]

        public virtual Department Department { get; set; }
    }
}