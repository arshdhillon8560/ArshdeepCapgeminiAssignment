using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCExampleDemo.Models;

namespace MVCExampleDemo.Controllers
{
    public class DogController : Controller
    {
        // Static list to store dogs
        static private List<dog> dogs = new List<dog>();

        // GET: DogController
        public ActionResult Index()
        {
            return View(dogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            dog d = new dog();
            foreach(dog Dog in dogs){
                if (Dog.Id == id)
                {
                    d.Id = Dog.Id;
                    d.Name = Dog.Name;
                    d.Age = Dog.Age;
                }
            }
            return View(d);
        }

        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(dog d)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
            var d = dogs.FirstOrDefault(x => x.Id == id);
            return View(d);
        }

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(dog d)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", d);
                }
                else
                {
                    foreach (dog Dog in dogs)
                    {
                        if (Dog.Id == d.Id)
                        {
                            Dog.Name = d.Name;
                            Dog.Age = d.Age;
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View("Edit", d);
            }
        }

        // GET: DogController/Delete/5
        public ActionResult Delete(int id)
        {
            var d = dogs.FirstOrDefault(x => x.Id == id);
            return View(d);
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, dog d)
        {
            try
            {
                var dogToDelete = dogs.FirstOrDefault(x => x.Id == id);

                if (dogToDelete != null)
                {
                    dogs.Remove(dogToDelete);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(d);
            }
        }
        public ActionResult DirectDelete(int id)
        {
            var d = dogs.FirstOrDefault(x => x.Id == id);
            if (d != null)
            {
                dogs.Remove(d);
            }
            return RedirectToAction("Index");
        }
    }
}