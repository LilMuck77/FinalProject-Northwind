using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using System.Linq;

namespace Northwind.Controllers
{
    public class ProductController : Controller
    {
        // this controller depends on the NorthwindRepository
        private NorthwindContext _northwindContext;
        public ProductController(NorthwindContext db) => _northwindContext = db;
        public IActionResult Category() => View(_northwindContext.Categories.OrderBy(c => c.CategoryName));
        public IActionResult Index(int id) => View(_northwindContext.Products.Where(p => p.CategoryId == id && p.Discontinued == false).OrderBy(p => p.ProductName));
    }
}
