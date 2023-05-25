﻿using AutoMapper;
using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using EmployeeManagement.Persistence;
using EmployeeManagement.Services.Implementations;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly EmployeeContext _employeeContext;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IMapper mapper, 
            DataContext context, 
            EmployeeContext employeeContext,
            IEmployeeService employeeService
            
            )
        {
            _mapper = mapper;
            _context = context;
            _employeeContext = employeeContext;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> JobTitle(JobTitle model)
        {
            var registerNumber = _employeeContext.Id;
            var result = await _employeeService.RegisterJob(registerNumber, model);

            if (result.IsSuccess)
            {
                return RedirectToAction("JobHistory");
            }
            else
            {
                _employeeContext.ErrorMessage = result.Error ?? "Erro ao cadastrar empregado";
                return RedirectToAction("Error");
            }
        }

        public IActionResult JobTitle(int id) 
        {
            _employeeContext.Id = id;
            return View();
        }

        
        public async Task<IActionResult> JobHistory(int id)
        {
            var empId = _employeeContext.Id;
            var result = await _employeeService.GetJobHistory(id != 0 ? id : empId);
            if (result.IsSuccess)
            {
                var jobTitles = result.Value;
                return View(jobTitles);
            }
            else
            {
                _employeeContext.ErrorMessage = result.Error ?? "erro ao listar cargos";
                return RedirectToAction("Error");
            }
        }
    }
}