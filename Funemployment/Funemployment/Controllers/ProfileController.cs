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

			// Make sure that the player object is not null. If it is not, 
			// then set the id of the player to the key/value pair ofthe cookie. 
			if(player != null)
			{
				//Response is a part of hte Controller Base and is a part of the 
				// HttpResposne object. 
				// Append means we get to "add" a new cookie
				Response.Cookies.Append("Player", player.ID.ToString());
			}
			return RedirectToAction("Index", player);
		}

    public async Task<IActionResult> PlayerAllAnswers(int id)
    {
      List<Answer> bQAnswers = _context.AnswerTable.Where(a => a.PID == id && a.BQID != 0).Select(s => s).ToList();

      List<Answer> tQAnswers = _context.AnswerTable.Where(a => a.PID == id && a.TQID != 0).Select(s => s).ToList();

      if (bQAnswers.Count != 0 && tQAnswers.Count != 0)
      {
        return View(await PlayerAllAnswersViewModel.FromPlayerIDAsync(id, _context, bQAnswers, tQAnswers));
      }
      else
      {
        return RedirectToAction("Error", "Profile");
      }
    }

    public IActionResult Error()
    {
      return View();
    }
	}
}