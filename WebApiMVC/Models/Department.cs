using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual HashSet<Employee> Employees { get; set; }
    }
}