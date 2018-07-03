using Funemployment.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funemployment.Controllers
{
    public class HomeController : Controller
    {
        private FunemploymentDbContext _context;

        public HomeController(FunemploymentDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username)
        {
            var player = _context.PlayerTable.FirstOrDefault(p => p.Username == username);
            if (player != null)
            {
                return RedirectToAction("Index", "Profile", player);
            }

            return RedirectToAction("Create", "Profile");
        }
    }
}
