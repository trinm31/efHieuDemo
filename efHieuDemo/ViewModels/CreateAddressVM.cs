using efHieuDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace efHieuDemo.ViewModels;

public class CreateAddressVM
{
    public Address Address { get; set; }
    public List<SelectListItem> Peoples { get; set; }
}