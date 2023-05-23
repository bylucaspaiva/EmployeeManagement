using EmployeeManagement.DTOs;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> RegisterEmployee(EmployeeDTO employeeDTO);
        Task<Employee> GetEmployee(string registerNumber);
        Task<Employee> UpdateEmployee(EmployeeDTO employeeDTO);
        Task<Employee> DismissEmployee(string registerNumber);
    }
}
