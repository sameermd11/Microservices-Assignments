using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication6.Models
{
    public class Employee
    {
        [Key]
        public int Eid { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public float Salary { get; set; }
        public string Address { get; set; }
    }

    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

    }
}
