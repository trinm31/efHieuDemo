using System.Diagnostics;
using efHieuDemo.DbContext;
using Microsoft.AspNetCore.Mvc;
using efHieuDemo.Models;

namespace efHieuDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _db;
    
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
    {
        _logger = logger;
        _db = db;
    }

    public IActionResult Index()
    {
        // var people = new People()
        // {
        //     Name = "Nguyen Minh Tri",
        //     Age = 12,
        //     Description = "dep trai"
        // };
        //
        // _db.Peoples.Add(people);
        // _db.SaveChanges();

        // var people = _db.Peoples.Find(1);
        // _db.Peoples.Remove(people);
        // _db.SaveChanges();

        //var peoples = _db.Peoples.ToList();

        //var peoples = _db.Peoples.Where(p => p.Age >= 12).ToList();
        var peoples = _db.Peoples.ToList();
        return View(peoples);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Test()
    {
        var people = _db.Peoples.ToList();
        return View(people);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}