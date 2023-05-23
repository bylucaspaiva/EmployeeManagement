using EmployeeManagement.DTOs;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<Employee> RegisterCompany(EmployeeDTO employeeDTO);
        Task<List<Employee>> GetEmployees(string companyCNPJ);
        Task<Employee> GetEmployee(string registerNumber);
        Task<List<Company>> GetCompanies();
        Task<Employee> UpdateEmployee(EmployeeDTO employeeDTO);
        Task<Employee> DismissEmployee(string registerNumber);
        Task<Employee> RegisterEmployee(EmployeeDTO employeeDTO);

    }
}
