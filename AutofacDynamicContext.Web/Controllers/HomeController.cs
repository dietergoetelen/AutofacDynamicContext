using AutofacDynamicContext.Domain;
using AutofacDynamicContext.Domain.Enums;
using AutofacDynamicContext.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AutofacDynamicContext.Web.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeService _employeeService;
        private EnvironmentContext _environment;

        public HomeController(IEmployeeService employeeService, EnvironmentContext environment)
        {
            _employeeService = employeeService;
            _environment = environment;
        }

        public async Task<ActionResult> Index()
        {
            _environment.Environment = CurrentEnvironment.PreProd;

            // Get preproduction data
            var employees = await _employeeService.GetEmployeesAsync();

            _environment.Environment = CurrentEnvironment.Prod;

            // Get production data
            employees = await _employeeService.GetEmployeesAsync();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}