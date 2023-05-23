using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult RegisterCompany()
        {
            return View();
        }
    }
}
