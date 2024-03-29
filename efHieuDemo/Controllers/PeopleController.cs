using efHieuDemo.DbContext;
using efHieuDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace efHieuDemo.Controllers;

public class PeopleController : Controller
{
    private readonly ApplicationDbContext _db;
    public PeopleController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        var people = _db.Peoples.ToList();
        return View(people);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View(new People());
    }
    
    [HttpPost]
    public IActionResult Create(People people)
    {
        if (ModelState.IsValid)
        {
            _db.Peoples.Add(people);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        return View(people);
    }
    
    public IActionResult Update(int peopleId)
    {
        var people = _db.Peoples.Find(peopleId);
        return View(people);
    }
    
    [HttpPost]
    public IActionResult Update(People people)
    {
        var peopleFromDb = _db.Peoples.Find(people.Id);
        peopleFromDb.Name = people.Name;
        peopleFromDb.Age = people.Age;
        peopleFromDb.Description = people.Description;
        
        _db.Peoples.Update(peopleFromDb);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    public IActionResult Delete(int test)
    {
        var people = _db.Peoples.Find(test);
        _db.Peoples.Remove(people);
        _db.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
}