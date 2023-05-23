using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using EmployeeManagement.Persistence;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;

        public Task<JobHistory> GetJobHistory(string registerNumber)
        {
            throw new NotImplementedException();
        }

        public Task<JobTitle> GetJobTitle(string registerNumber)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(string registerNumber)
        {
            throw new NotImplementedException();
        }


    }
}
