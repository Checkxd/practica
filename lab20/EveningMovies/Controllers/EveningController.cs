using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EveningMovies.Models;

namespace EveningMovies.Controllers
{
	public class EveningController : Controller
	{
		private static List<Movie> movies = new List<Movie>();

		public ActionResult Index()
		{
			return View(movies);
		}

		public ActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Add(Movie movie)
		{
			movie.Id = movies.Count + 1;
			movie.DateAdded = DateTime.Now;
			movies.Add(movie);
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			var movie = movies.FirstOrDefault(m => m.Id == id);
			if (movie == null) return NotFound();
			return View(movie);
		}
	}
}
