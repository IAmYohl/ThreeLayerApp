using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            //business logic would be written here 
            return await _employeeRepository.GetEmployeesAsync();
        }

        public async Task AddEmployeeAsync(Employee newEmployee)
        {
            //example logic: no employees with sal higher than 250k
            if (newEmployee != null && newEmployee.Salary <= 250_000)
            {
                await _employeeRepository.AddEmployeeAsync(newEmployee);
            }
        }
        public async Task<Employee> GetEmployeeWithIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeWithIdAsync(id);
        }

        public async Task EditEmployeeAsync(Employee newEmployee)
        {
            //example logic: no employees with sal higher than 250k
            if (newEmployee != null && newEmployee.Salary <= 250_000)
            {
                await _employeeRepository.EditEmployeeAsync(newEmployee);
            }
        }
        public async Task<Employee> EmployeeDetailsAsync(int id)
        {
            return await _employeeRepository.EmployeeDetailsAsync(id);
        }

        public async Task DeleteEmployeeAsync(Employee employeeToDelete)
        {
            if (employeeToDelete != null) { 
            await _employeeRepository.DeleteEmployeeAsync(employeeToDelete);
            }
        }
    }
}
