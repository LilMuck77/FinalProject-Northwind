using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Northwind.Models;
using System.Linq;
using System;

namespace Northwind.Controllers
{
    public class EmployeeController : Controller
    {
        // this controller depends on the NorthwindRepository
        private NorthwindContext _northwindContext;
        public EmployeeController(NorthwindContext db) => _northwindContext = db;
        //need to implement northwind-employee doesnt have any meaning right now. figure out where norhtwind customer came from.

        [Authorize(Roles = "northwind-customer")]
        public IActionResult ManageDiscounts() => View(_northwindContext.Discounts.Where(d => d.StartTime <= DateTime.Now && d.EndTime > DateTime.Now));
        public IActionResult AddDiscount() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDiscount(Discount model)
        {

            // _northwindContext.AddDiscount(model);
            // return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                if (_northwindContext.Discounts.Any(d => d.Code == model.Code))
                {
                    ModelState.AddModelError("", "Code must be unique");
                }
                else
                {
                    _northwindContext.AddDiscount(model);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public IActionResult DeleteDiscount(int id)
        {
            _northwindContext.DeleteDiscount(_northwindContext.Discounts.FirstOrDefault(d => d.DiscountId == id));
            return RedirectToAction("Index");
        }

        // public IActionResult EditDiscount(int id)
        // {

        // }
        public IActionResult NewEmployeeAccount() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewEmployeeAccount(Employee model)
        {
            _northwindContext.NewEmployeeAccount(model);
            return RedirectToAction("Index");
        }



        // public IActionResult AddDiscount(Discount model)
        // 
        //     if (ModelState.IsValid)
        //     {
        //         if (_northwindContext.Discount.Any(d => d.Code == model.Code))
        //         {
        //             ModelState.AddModelError("", Code must be unique");
        //             }
        //         else
        //         {
        //             _northwindContext.AddDiscount(model);
        //             return RedirectToAction("Index");
        //         }
        //     }
        //     return View();
        // }

    }
}