using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using EmployeeManagement.Services.Interfaces;

namespace EmployeeManagement.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        public Task<Employee> DismissEmployee(string registerNumber)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetCompanies()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployee(string registerNumber)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployees(string companyCNPJ)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> RegisterCompany(EmployeeDTO employeeDTO)
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
