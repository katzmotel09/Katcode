using Katcode.Data;
using Katcode.Models;
using Katcode.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Katcode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KatCodeContext _context;

		public HomeController(KatCodeContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
			HomeViewModel viewModel = new HomeViewModel(_context);
			return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Logs()
        {
            return View();
        }

        public IActionResult About() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
	}
}