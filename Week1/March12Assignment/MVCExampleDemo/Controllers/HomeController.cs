using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCExampleDemo.Models;

namespace MVCExampleDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string sampledemo1()
        {
            return "Arsh";
        }

        public string sampledemo2(int age,string name)
        {
            return $"The name {name} is {age}";
        }

        public IActionResult sampledemo3()
        {
            int age = 34;
            string name = "Arsh Dhillon";
            ViewBag.Name = name;
            ViewBag.age = age;
            ViewData["Message"] = "Welcome to Asp.net core learning";
            ViewData["Year"] = DateTime.Now.Year;
            Console.WriteLine("finished");
            return View();
        }

        Employee obj = new Employee()
        {
            EmployeeID = 101,
            EmpName = "Arsh",
            Salary = 34000
        };

        List<Employee> emplist = new List<Employee>()
        {
            new Employee{ EmployeeID=101,EmpName="Arsh", Salary=34000,ImageUrl="/images/Arshdeep Singh Photo.png", DeptID=30},
            new Employee{ EmployeeID=102,EmpName="Arshdeep", Salary=44000,ImageUrl="/images/new profile image.png",DeptID=20},

        };

        List<Dept> deptlist = new List<Dept>()
        {
         new Dept{DeptID=10,DeptName="Sales"},
         new Dept{DeptID=20,DeptName="HR"},
         new Dept{DeptID=30,DeptName="Software"}
        };

        public IActionResult collectionofdepts()
        {
            return View(deptlist);
        }

        public IActionResult EmpsInDept(int deptid)
        {
            var deptemployee = emplist.Where(x => x.DeptID == deptid).ToList();
            return View(deptemployee);
        }
        public IActionResult collectionofobjectspassing()
        {
            return View(emplist);
        }

        public IActionResult singleobjectpassing()
        {
            return View(obj);
        }

        public IActionResult Display()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var employee = emplist.FirstOrDefault(e => e.EmployeeID == id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        public IActionResult searchemp(int empid)
        {   Employee? emp = emplist.FirstOrDefault(e => e.EmployeeID == empid);

            return View(emp);
        }

        public IActionResult mixedobjectpassing(int empid)
        {   
            var query1 =deptlist.ToList();
            Employee emp = emplist.Where(x => x.EmployeeID == empid).FirstOrDefault();
            var query2 = emp;
            if (query2 == null)
            {
                return NotFound();
            }
            EmpdeptViewModel obj = new EmpdeptViewModel()
            {
                deptlist = query1,
                emp = query2,
                date = DateTime.Now,
            };

            return View(obj);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
