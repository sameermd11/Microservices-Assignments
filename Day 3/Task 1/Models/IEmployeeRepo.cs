using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public interface IEmployeeRepo
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeByID(int Id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
        Employee DeleteEmployee(int Id);
    }
}
