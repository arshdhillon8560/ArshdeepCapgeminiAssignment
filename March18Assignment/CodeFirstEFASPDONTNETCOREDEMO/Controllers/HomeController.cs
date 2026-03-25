using CodeFirstEFASPDONTNETCOREDEMO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CodeFirstEFASPDONTNETCOREDEMO.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventContext _context;

        public HomeController(ILogger<HomeController> logger, EventContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult displayemp()
        {
            var emps = _context.employees.ToList();
            return View(emps);
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("displayemp");
            }
            return View(employee);
        }

        public IActionResult Details(int id)
        {
            var employee = _context.employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            var emp = _context.employees.Find(id);
            if (emp==null)
            {
                return BadRequest();
            }
            return View(emp);
        }

        [HttpPost]

        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("displayemp");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = _context.employees.Find(id);
            if (emp.Id != id)
            {
                return BadRequest();
            }
            return View(emp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int id,Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (employee!=null)
            {
                _context.employees.Remove(employee);
                _context.SaveChanges();
                return RedirectToAction("displayemp");
            }
            return View(employee);
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
