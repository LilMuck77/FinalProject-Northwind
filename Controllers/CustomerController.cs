using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System.Linq;

namespace Northwind.Controllers
{
    public class CustomerController : Controller
    {
        // this controller depends on the NorthwindRepository
        private NorthwindContext _northwindContext;
        public CustomerController(NorthwindContext db) => _northwindContext = db;
        public IActionResult Register() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (_northwindContext.Customers.Any(c => c.CompanyName == customer.CompanyName))
                {
                    ModelState.AddModelError("", "Company Name must be unique");
                }
                else
                {
                    _northwindContext.AddCustomer(customer);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}
