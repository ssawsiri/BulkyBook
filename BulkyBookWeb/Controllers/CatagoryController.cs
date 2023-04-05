using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CatagoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Catagory> objCatagoryList = _db.Catagories;
            return View(objCatagoryList);
        }
        //GET
        public IActionResult Create()
        {
           return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagory obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("name", "The Display Order cannot be the same as Name");
            }
            if (ModelState.IsValid) //Server side validation
            {
                _db.Catagories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null | id == 0)
            {
                return NotFound();
            }
            var catagoryFromDb = _db.Catagories.Find(id);
            //var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(u=>u.Id == id);
            //var catagoryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id == id);
            if (catagoryFromDb == null)
            {
                return NotFound(); 
            }
            return View(catagoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catagory obj)
        {
            if (obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("name", "The Display Order cannot be the same as Name");
            }
            if (ModelState.IsValid) //Server side validation
            {
                _db.Catagories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null | id == 0)
            {
                return NotFound();
            }
            var catagoryFromDb = _db.Catagories.Find(id);
            //var catagoryFromDbFirst = _db.Catagories.FirstOrDefault(u=>u.Id == id);
            //var catagoryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id == id);
            if (catagoryFromDb == null)
            {
                return NotFound();
            }
            return View(catagoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Catagories.Find(id); 
            if (obj == null) 
            {
                return NotFound();
            }
            
            _db.Catagories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
