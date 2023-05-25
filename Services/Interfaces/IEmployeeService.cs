using EmployeeManagement.Core;
using EmployeeManagement.DTOs;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<JobTitle> GetJobTitle(string registerNumber);
        Task<Result<List<JobTitle>>> GetJobHistory(int id);
        Task<Result<JobTitle>> RegisterJob(int id, JobTitle model);
        Task<Result<JobTitle>> DismissJob(int id);

        Task<Result<Employee>> DismissEmploye(int id);
    }
}
