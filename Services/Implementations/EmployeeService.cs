using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using EmployeeManagement.Persistence;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public Task<Employee> DismissEmployee(string registerNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(string registerNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> RegisterEmployee(EmployeeDTO employeeDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            throw new NotImplementedException();
        }
    }
}
