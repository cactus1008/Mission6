using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private MovieDataContext _context;
        public HomeController(MovieDataContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }
        [HttpPost]
        //make sure app doesnt crash
        public IActionResult EnterMovie(Movie response)
        {
            if (!ModelState.IsValid)
            {
                return View(response);
            }

            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
