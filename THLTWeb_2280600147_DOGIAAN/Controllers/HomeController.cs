using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using THLTWeb_2280600147_DOGIAAN.Models;
using THLTWeb_2280600147_DOGIAAN.Repositories;

namespace THLTWeb_2280600147_DOGIAAN.Controllers
{
    public class HomeController : Controller
    {
        private readonly AnDbContext _context;
        public HomeController(AnDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
