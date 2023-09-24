using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloMVCWorld.Models;
using Microsoft.AspNetCore.Mvc.Razor;
using HelloMVCWorld.Data;

namespace Efficienly.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;

        }

        // POST: /Home/Edit
        //  This attribute is used in ASP.NET MVC to specify that an action method should be invoked for HTTP POST requests.
        //  It is typically used when submitting form data or performing actions that modify data on the server.
        [Route(@"student/{slug:regex(^[[0-9]]{{1,7}}\-[[a-z0-9\-]]{{3,50}}$)}")]
        // [Route("student/{entryId:range(1, 10):int}/{slug:minlength(3)}")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Home/Profile
        //  This attribute is used in ASP.NET MVC to specify that an action method should be invoked for HTTP POST requests.
        //  It is typically used when submitting form data or performing actions that modify data on the server.
        [HttpPost]
        public async Task<IActionResult> Index([Bind("Id,Name,Phone,Email,Address,City,DoB,Gendeer,Occupation")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Redirect to Home/Index
            }


            return View(student);
        }

        [Route("{id}")]
        public IActionResult Details(int id)
        {
            return Content("Product #" + id);
        }
    }
}
