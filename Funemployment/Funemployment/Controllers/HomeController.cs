using Funemployment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funemployment.Controllers
{
    public class HomeController : Controller
    {
        private FunemploymentDbContext _context;

		private readonly IConfiguration Configuration;


		public HomeController(FunemploymentDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
			
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username)
        {
            var player = _context.PlayerTable.FirstOrDefault(p => p.Username == username);

			//Make sure that the player object is not null. If this is not null, then
			// that means that the username exists in the db. 
            if (player != null)
            {
				//Response is a part of hte Controller Base and is a part of the 
				// HttpResposne object. 
				// Append means we get to "add" a new cookie
				Response.Cookies.Append("Player", player.ID.ToString());

				return RedirectToAction("Index", "Profile", player);
            }

            return RedirectToAction("Create", "Profile");
        }
    }
}
