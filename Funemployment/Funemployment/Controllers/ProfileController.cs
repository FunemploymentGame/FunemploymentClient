using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funemployment.Data;
using Funemployment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Funemployment.Controllers
{
	public class ProfileController : Controller
	{

		private FunemploymentDbContext _context;

		private readonly IConfiguration Configuration;

		public ProfileController(FunemploymentDbContext context, IConfiguration configuration)
		{
			_context = context;
			Configuration = configuration;

		}

		public IActionResult Index(Player player)
		{
			return View(player);
		}

		/// <summary>
		/// sends user to Create View form
		/// </summary>
		/// <returns>view</returns>
		[HttpGet]
		public IActionResult Create()
		{


			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Player player)
		{
			await _context.PlayerTable.AddAsync(player);
			await _context.SaveChangesAsync();
			// Add the player's name and ID to a cookie
			

			return RedirectToAction("Index", player);
		}




	}
}