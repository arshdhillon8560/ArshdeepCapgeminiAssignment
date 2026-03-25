using Layout_SectionsDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Layout_SectionsDemo.Controllers
{
    public class DepartmentController : Controller
    {
        List<Department> deptlist = new List<Department>()
            {
                new Department{DeptID=10,DeptName="Sales"},
                new Department{DeptID=20,DeptName="HR"},
                new Department{DeptID=30,DeptName="Software"}
            };

        public IActionResult Index()
        {
            return View(deptlist);
        }
    }
}
