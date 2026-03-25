using Microsoft.AspNetCore.Mvc;
using Routing_demo.Models;

namespace Routing_demo.Controllers
{
    public class StudentController : Controller
    {
        List<Student> _studlist = new List<Student>()
        {
            new Student{Id=101,Name="kiran", Class="class4"},
            new Student{Id=102,Name="Mohan", Class="class7"},
            new Student{Id=103,Name="Suhana", Class="class8"},

        };

        [Route("studs")]
        public IActionResult GetAllStudents()
        {
            return View(_studlist);
        }

        [Route("studs/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student =_studlist.FirstOrDefault(x => x.Id == id);

            return View(student);
        }

        [Route("studsfew")]
        public IActionResult fewcolumns()
        {
            var fewcolumns = _studlist.Select(x => new Student
            {
               Class=x.Class,
               Name=x.Name
            });
            return View(fewcolumns);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
