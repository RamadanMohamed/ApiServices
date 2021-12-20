using System;
using System.Data.Entity;
using System.Linq;

namespace WebApiService.Models
{
    public class Model : DbContext
    {
        
        public Model()
            : base("name=Model")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }

   
}