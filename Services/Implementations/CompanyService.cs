using AutoMapper;
using EmployeeManagement.Core;
using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using EmployeeManagement.Persistence;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EmployeeManagement.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly ILogger<Company> _logger;

        public CompanyService(HttpClient httpClient, IMapper mapper, DataContext context, ILogger<Company> logger)
        {
            _httpClient = httpClient;
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public Task<Employee> DismissEmployee(string registerNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Company>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public Task<Employee> GetEmployee(string registerNumber)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetEmployees(string companyCNPJ)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Company>> RegisterCompany(Company company)
        {

            var isCnpjActiveResult = await IsCNPJActive(company.CNPJ);

            if (!isCnpjActiveResult.IsSuccess)
            {
                return Result<Company>.Failure("CNPJ não está ativo.");
            }

            _context.Companies.Add(company);
            var result = await _context.SaveChangesAsync() > 0;
            if (!result)
            {
                return Result<Company>.Failure("Falha ao salvar a empresa no banco de dados.");
            }

            return Result<Company>.Success(company);
        }

        public async Task<Result<bool>> IsCNPJActive(string cnpj)
        {
            var response = await _httpClient.GetAsync($"https://www.receitaws.com.br/v1/cnpj/{cnpj}");

            if (!response.IsSuccessStatusCode)
            {
                return Result<bool>.Failure("Não conectou a api.");
            }

            var companyData = JsonConvert.DeserializeObject<CompanyData>(await response.Content.ReadAsStringAsync());

            return companyData.Status == "OK" ? Result<bool>.Success(true) : Result<bool>.Failure("false");
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
