using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public class EmployeeRepository : IEmployeeRepository //implementing the interace, meaning we have to implement all of the methods that exist in it
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            this._context = applicationDbContext;
        }

        //Implement GetEmployeesAsync method from our IEmployeeRepository interface
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task AddEmployeeAsync(Employee newEmployee)
        {
            //NOT NECESSARY:
            //var employee = new Employee
            //{
            //    FirstName = newEmployee.FirstName,
            //    LastName = newEmployee.LastName,
            //    Position = newEmployee.Position,
            //    Salary = newEmployee.Salary
            //};
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }
        public async Task<Employee> GetEmployeeWithIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);  
        }
        public async Task EditEmployeeAsync(Employee newEmployee)
        {
            var employee = await GetEmployeeWithIdAsync(newEmployee.Id);
            employee.FirstName = newEmployee.FirstName;
            employee.LastName = newEmployee.LastName;
            employee.Position = newEmployee.Position;
            employee.Salary = newEmployee.Salary;
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> EmployeeDetailsAsync(int id)
        {
            var employee = await GetEmployeeWithIdAsync(id);
            return employee;
        }

        public async Task DeleteEmployeeAsync(Employee employeeToDelete)
        {
            _context.Employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
