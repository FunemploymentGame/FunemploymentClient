using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Funemployment.Data;
using Funemployment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Funemployment.Controllers
{
	public class BehavioralController : Controller
	{
		private FunemploymentDbContext _context;

		public BehavioralController(FunemploymentDbContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Get all behavioral questions from the API
		/// </summary>
		/// <returns>a list of behavioral questions to the view or not found</returns>
		public async Task<IActionResult> Index(int id)
		{

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://funemploymentapi.azurewebsites.net");

				var response = client.GetAsync("/api/behavior/").Result;

				if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
				{
					var stringResult = await response.Content.ReadAsStringAsync();

					var obj = JsonConvert.DeserializeObject<List<BehaviorQuestion>>(stringResult);
					return View(obj);
				}
				return NotFound();
			}
		}

		/// <summary>
		/// gets data for exactly one behavioral questions
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetOneBQ(int? id)
		{
			if (id.HasValue)
			{
				return View(await OneBQViewModel.FromIDAsync(id.Value, _context));
			}
			return NoContent();
		}

        /// <summary>
        /// Sends user to the View where a form to create new answer
        /// </summary>
        /// <param name="id">The ID of the BQ </param>
        /// <returns>the view with a view model</returns>
		[HttpGet]
		public IActionResult CreateAnswer(int id)
		{
			CreateAnswerViewModel cavm = new CreateAnswerViewModel();
			cavm.Ans = new Answer();
			cavm.ID = id;
			return View(cavm);
		}

        /// <summary>
        /// Recieves the user input answer from the view's form and saves the answer to the answertable
        /// and adds points to the player.
        /// </summary>
        /// <param name="cavm">create answer view model</param>
        /// <returns>not found or the profile view</returns>
		[HttpPost]
		public async Task<IActionResult> CreateAnswer(CreateAnswerViewModel cavm)
		{
			cavm.Ans.BQID = cavm.ID;

			//Check and see if the cookie has a valid number in it. 
			// if it does, then save that to PID of the Answer object.
			
			if(Int32.TryParse(Request.Cookies["Player"], out int userId))
			{
				cavm.Ans.PID = userId;
			}

            var player = _context.PlayerTable.FirstOrDefault(p => p.ID == cavm.Ans.PID);
            if (player == null)
            {
                return NotFound();
            }
            player.Points++;
            _context.PlayerTable.Update(player);

            await _context.AnswerTable.AddAsync(cavm.Ans);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index", "Profile", player);
		}
	}
}