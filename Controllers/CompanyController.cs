using EmployeeManagement.Models;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeManagement.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Error()
        {
            var errorMessage = TempData["ErrorMessage"] as string;

            var companyErrorView = new CompanyErrorView
            {
                ErrorMessage = errorMessage
            };

            if(!string.IsNullOrEmpty(companyErrorView.ErrorMessage))
                return View(companyErrorView);
            companyErrorView.ErrorMessage = "Erro ao cadastrar empresa";
            return View(companyErrorView);

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
                    TempData["ErrorMessage"] = newCompany.Error;

                    return RedirectToAction("Error");
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> ListCompanies()
        {
            var companies = await _companyService.GetCompanies();
            return View(companies);
        }
    }
}
