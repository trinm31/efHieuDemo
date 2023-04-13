using efHieuDemo.DbContext;
using efHieuDemo.Models;
using efHieuDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace efHieuDemo.Controllers;

public class AddressController : Controller
{
    private readonly ApplicationDbContext _db;
    public AddressController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    // GET
    public IActionResult Index()
    {
        var addresses = _db.Addresses.ToList();
        return View(addresses);
    }
    
    public IActionResult Create()
    {
        var addressVm = new CreateAddressVM()
        {
            Address = new Address(),
            Peoples = _db.Peoples.ToList().Select(people =>
                new SelectListItem
                {
                    Text = people.Name,
                    Value = people.Id.ToString()
                }
            ).ToList()
        };
        return View(addressVm);
    }
    
    [HttpPost]
    public IActionResult Create(CreateAddressVM createAddressVm)
    {
        if (createAddressVm.Address.Position != null && createAddressVm.Address.PeopleId != null)
        {
            _db.Addresses.Add(createAddressVm.Address);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        createAddressVm.Peoples = _db.Peoples.ToList().Select(people =>
            new SelectListItem
            {
                Text = people.Name,
                Value = people.Id.ToString()
            }
        ).ToList();
        
        return View(createAddressVm);
    }
    
    [HttpGet]
    public IActionResult Delete(int addressId)
    {
        var address = _db.Addresses.Find(addressId);
        _db.Addresses.Remove(address);
        _db.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
}