using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogApp.Models;

namespace DogApp.Controllers
{
    public class DogController : Controller
    {
        // GET: DogController

        private static List<Dog> dogs = new List<Dog>();
        private readonly IWebHostEnvironment _environment;

        public DogController(IWebHostEnvironment environment)
        {
            _environment = environment; 
        }
        public ActionResult Index()
        {
            return View(dogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            return View(dogs.FirstOrDefault(x=>x.ID==id));
        }

        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog d , IFormFile imageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    d.ID = dogs.Count + 1;

                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var imageName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                        var path = Path.Combine(_environment.WebRootPath, "images", imageName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            imageFile.CopyTo(stream);
                        }

                        d.ImagePath = "/images/" + imageName;
                    }

                    dogs.Add(d);

                    return RedirectToAction("Index");
                }

                return View(d);
            }
            catch
            {
                return View(d);
            }
        }

        // GET: DogController/Edit/5
        public ActionResult Edit(int id)
        {
            var dog = dogs.FirstOrDefault(x => x.ID == id);
            return View(dog);
        }

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog updatedDog)
        {
            var dog = dogs.FirstOrDefault(x => x.ID == id);

            if (dog != null)
            {
                dog.Name = updatedDog.Name;
                dog.Age = updatedDog.Age;
                dog.Description = updatedDog.Description;
            }

            return RedirectToAction("Index");
        }

        // GET: DogController/Delete/5
        public ActionResult Delete(int id)
        {
            var dog = dogs.FirstOrDefault(x => x.ID == id);
            return View(dog);
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog d)
        {
            var dog = dogs.FirstOrDefault(x => x.ID == id);

            if (dog != null)
            {
                dogs.Remove(dog);
            }

            return RedirectToAction("Index");
        }
    }
}
