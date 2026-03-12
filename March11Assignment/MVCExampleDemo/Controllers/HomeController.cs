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
            new Employee{ EmployeeID=101,EmpName="Arsh", Salary=34000,ImageUrl="/images/Arshdeep Singh Photo.png"},
            new Employee{ EmployeeID=102,EmpName="Arshdeep", Salary=44000,ImageUrl="/images/new profile image.png"},

        };

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
