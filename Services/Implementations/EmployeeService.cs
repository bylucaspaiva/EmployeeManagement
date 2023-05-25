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

        public async Task<Result<Employee>> DismissEmploye(int id)
        {
            var employee = await _context.Employees
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (employee == null) return Result<Employee>.Failure("Colaborador não encontrado");

            employee.IsActive = false;

            _context.Employees.Update(employee);

            var success = await _context.SaveChangesAsync() > 0;

            if (success) return Result<Employee>.Success(employee);

            return Result<Employee>.Failure("Falha ao demitir funcionário");
        }

        public async Task<Result<JobTitle>> DismissJob(int id)
        {
            var jobTitle = await _context.JobTitles
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (jobTitle == null) return Result<JobTitle>.Failure("Cargo não encontrado");

            var now = DateTime.UtcNow;

            if (jobTitle.StartDate < now )
            {
                jobTitle.TerminationDate = now;
            }

            _context.JobTitles.Update(jobTitle);

            var success = await _context.SaveChangesAsync() > 0;

            if (success) return Result<JobTitle>.Success(jobTitle);
            
            return Result<JobTitle>.Failure("Falha ao terminar cargo");
        }

        public async Task<Result<List<JobTitle>>> GetJobHistory(int id)
        {
            var jobTitles = await _context.Employees
                .Where(e => e.Id == id)
                .SelectMany(e => e.JobHistory)
                .OrderBy(j => j.StartDate)
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
                StartDate = model.StartDate,
            };

            jobTitle.Employee = employee;
            jobTitle.EmployeeId = id;
            employee.JobHistory.Add(jobTitle);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Result<JobTitle>.Success(jobTitle);

            return Result<JobTitle>.Failure("Erro ao salvar cargo!");
        }
    }
}
