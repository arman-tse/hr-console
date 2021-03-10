using System.Web.Mvc;
using AdventureWorks.Services.HumanResources;
using Microsoft.ApplicationInsights;

namespace AdventureWorks.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private TelemetryClient telemetry = new TelemetryClient();

        // GET: Departments
        public ActionResult Index()
        {
            DepartmentService departmentService = new DepartmentService();
            var departmentGroups = departmentService.GetDepartments();
            
            telemetry.TrackEvent("CUSTOM EVENT: /Department page is loaded");

            return View(departmentGroups);
        }

        // GET: Departments/Employees/{id}
        public ActionResult Employees(int id)
        {
            DepartmentService departmentService = new DepartmentService();
            var departmentEmployees = departmentService.GetDepartmentEmployees(id);
            var departmentInfo = departmentService.GetDepartmentInfo(id);

            ViewBag.Title = "Employees in " + departmentInfo.Name + " Department";

            telemetry.TrackEvent($"CUSTOM EVENT: /Department/Employee/{id} page is loaded");

            return View(departmentEmployees);
        }
    }
}
