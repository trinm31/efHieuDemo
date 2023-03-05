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
    public IActionResult Index()
    {
        var people = _db.Peoples.ToList();
        return View(people);
    }
    
    public IActionResult Create()
    {
        return View(new People());
    }
    
    [HttpPost]
    public IActionResult Create(People people)
    {
        _db.Peoples.Add(people);
        _db.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}