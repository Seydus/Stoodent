using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloMVCWorld.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using HelloMVCWorld.Data;

namespace HelloMVCWorld.Controllers
{
    // This class is an MVC Controller. It inherits from the Controller class provided by the .NET framework.
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Home/Edit
        // This attribute is used in ASP.NET MVC to specify that an action method should be invoked for HTTP GET requests.
        // It is typically used to retrieve data from the server or display information to the user.
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return _context.Student != null ?
                View(await _context.Student.ToListAsync()) :
                Problem("Entity set 'ApplicationDbContext.Student' is null.");
        }

        // GET: /Home/Edit
        // This attribute is used in ASP.NET MVC to specify that an action method should be invoked for HTTP GET requests.
        // It is typically used to retrieve data from the server or display information to the user.
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        // GET: /Home/Edit
        // This attribute is used in ASP.NET MVC to specify that an action method should be invoked for HTTP GET requests.
        // It is typically used to retrieve data from the server or display information to the user.
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return Content("Product details for #" + id);
        }
    }
}
