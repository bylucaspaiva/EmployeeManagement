using EmployeeManagement.DTOs;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> UpdateEmployee(string registerNumber);
        Task<JobTitle> GetJobTitle(string registerNumber);

        Task<JobHistory> GetJobHistory(string registerNumber);
    }
}
