using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task AddEmployeeAsync(Employee newEmployee);
        Task<Employee> GetEmployeeWithIdAsync(int id);
        Task EditEmployeeAsync(Employee newEmployee);
        Task<Employee> EmployeeDetailsAsync(int id);
        Task DeleteEmployeeAsync(Employee employeeToDelete);
    }
}
