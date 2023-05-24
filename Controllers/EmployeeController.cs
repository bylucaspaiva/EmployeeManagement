using AutoMapper;
using EmployeeManagement.DTOs;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
    }
}