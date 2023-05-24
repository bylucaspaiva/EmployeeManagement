using EmployeeManagement.Core;
using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<Result<Company>> RegisterCompany(Company company);
        Task<List<Employee>> GetEmployees(string companyCNPJ);
        Task<Employee> GetEmployee(string registerNumber);
        Task<List<Company>> GetCompanies();
        Task<Employee> UpdateEmployee(EmployeeDTO employeeDTO);
        Task<Employee> DismissEmployee(string registerNumber);
        Task<Employee> RegisterEmployee(EmployeeDTO employeeDTO);

    }
}
