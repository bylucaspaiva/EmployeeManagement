using EmployeeManagement.Core;
using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using EmployeeManagement.Persistence;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<List<JobTitle>>> GetJobHistory(int id)
        {
            var jobTitles = await _context.Employees
                .Where(e => e.Id == id)
                .SelectMany(e => e.JobHistory)
                .OrderBy(j =>  j.StartDate)
                .ToListAsync();

            return Result<List<JobTitle>>.Success(jobTitles);
        }

        public Task<JobTitle> GetJobTitle(string registerNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<JobTitle>> RegisterJob(int id, JobTitle model)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return Result<JobTitle>.Failure("Usuário não encontrado");

            var jobTitle = new JobTitle
            {
                Name = model.Name,
                CBO = model.CBO,
                ActivityDescription = model.ActivityDescription,
                StartDate   = model.StartDate,
            };

            jobTitle.Employee = employee;
            jobTitle.EmployeeId = id;
            employee.JobHistory.Add(jobTitle);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Result<JobTitle>.Success(jobTitle);

            return Result<JobTitle>.Failure("Erro ao salvar cargo!");
        }

        public Task<Employee> UpdateEmployee(string registerNumber)
        {
            throw new NotImplementedException();
        }
    }
}
