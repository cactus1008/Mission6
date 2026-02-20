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
            ViewBag.Categories = _context.Categories.ToList();
            return View(new Movie());
        }
        [HttpPost]
        //make sure app doesnt crash
        public IActionResult EnterMovie(Movie response)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(response);
            }

            _context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
        public IActionResult ViewMovies()
        {
            // Include the category info in the movies query so we can display it in the view
            var movies = _context.Movies.Include(m => m.Category).OrderBy(x => x.Title).ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Grab the record from the database that matches the id passed in
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList(); // Get list of majors from database to populate dropdown

            return View("EnterMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            // Check valitity of the form data
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View("EnterMovie", updatedInfo);
            }
            _context.Movies.Update(updatedInfo); // Update record in the database
            _context.SaveChanges();
            return RedirectToAction("ViewMovies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id);
            return View("Delete", recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie toDelete)
        {
            _context.Movies.Remove(toDelete); // Remove record from the database
            _context.SaveChanges();
            return RedirectToAction("ViewMovies");
        }
    }
}
