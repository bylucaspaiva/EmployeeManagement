using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using EmployeeManagement.Persistence;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeManagement.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private CompanyContext _companyContext;
        public CompanyController(ICompanyService companyService, CompanyContext companyContext)
        {
            _companyService = companyService;
            _companyContext = companyContext;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> ListEmployees(string id)
        {
            var result = await _companyService.GetEmployees(id);
            if (result.IsSuccess)
            {
                var employees = result.Value;
                return View(employees);
            }
            else
            {
                _companyContext.ErrorMessage = result.Error ?? "Erro ao listar empregados";
                return RedirectToAction("Error");
            }
        }

        public IActionResult Error()
        {
            var errorMessage = _companyContext.ErrorMessage;

            if (string.IsNullOrEmpty(errorMessage))
            {
                errorMessage = "Erro ao cadastrar empresa";
            }

            _companyContext.ErrorMessage = errorMessage;

            return View(_companyContext);

        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                var newCompany = await _companyService.RegisterCompany(company);

                if (newCompany.IsSuccess)
                {
                    return RedirectToAction("ListCompanies");
                }
                else
                {
                    _companyContext.ErrorMessage = newCompany.Error;

                    return RedirectToAction("Error");
                }
            }
            return BadRequest();
        }

        public IActionResult RegisterEmployee(string id)
        {
            _companyContext.CNPJ = id;
            return View();
        }

        public async Task<IActionResult> AddEmployee(EmployeeDTO employeeDTO)
        {
            var cnpj = _companyContext.CNPJ;
            var result = await _companyService.RegisterEmployee(employeeDTO, cnpj);

            if (result.IsSuccess)
            {
                return RedirectToAction("ListEmployees");
            }
            else
            {
                _companyContext.ErrorMessage = result.Error ?? "Erro ao cadastrar empregado";
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> ListCompanies()
        {
            var companies = await _companyService.GetCompanies();
            return View(companies);
        }


    }
}
