using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeDBContext _context;

        public EmployeeRepo(EmployeeDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees;
        }

        public Employee GetEmployeeByID(int Id)
        {
            return _context.Employees.Find(Id);
        }

        public Employee AddEmployee(Employee Emp)
        {
            _context.Employees.Add(Emp);
            _context.SaveChanges();
            return Emp;
        }

        public Employee UpdateEmployee(Employee emp)
        {
            var employee = _context.Employees.Attach(emp);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return emp;
        }

        public Employee DeleteEmployee(int Id)
        {
            Employee e = _context.Employees.Find(Id);
            if (e != null)
            {
                _context.Employees.Remove(e);
                _context.SaveChanges();
            }
            return e;
        }
    }
}
