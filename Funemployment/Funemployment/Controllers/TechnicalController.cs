using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Funemployment.Data;
using Funemployment.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Funemployment.Controllers
{
    public class TechnicalController : Controller
    {
        private FunemploymentDbContext _context;

        public TechnicalController(FunemploymentDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Queries the API for the list of all TQ questions.
        /// Deserialize the JSON to C# objects
        /// </summary>
        /// <returns>not found if no data or the view</returns>
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://funemploymentapi.azurewebsites.net");

                var response = client.GetAsync("/api/technical/").Result;

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();

                    var obj = JsonConvert.DeserializeObject<List<TechnicalQuestion>>(stringResult);
                    return View(obj);
                }
                return NotFound();
            }
        }

        /// <summary>
        /// Gets one TQ by the id and all of its answers
        /// </summary>
        /// <param name="id">The Id of the TQ</param>
        /// <returns>no content or view with a viewmodel</returns>
        [HttpGet]
        public async Task<IActionResult> GetOneTQ(int? id)
        {
            if (id.HasValue)
            {
                return View(await OneTQViewModel.FromIDAsync(id.Value, _context));
            }
            return NoContent();
        }

        /// <summary>
        /// Sends user to the View where a form to create new answer
        /// </summary>
        /// <param name="id">The id of the question</param>
        /// <returns>CreateAnswer view sending a viewmodel</returns>
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
        /// <param name="cavm">Create AnswerView Model</param>
        /// <returns>Not Found if the user is invalid, or the profile view</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAnswer(CreateAnswerViewModel cavm)
        {
            cavm.Ans.TQID = cavm.ID;

            
            if (Int32.TryParse(Request.Cookies["Player"], out int userId))
            {
                cavm.Ans.PID = userId;
            }
            //Save to the answer table
            await _context.AnswerTable.AddAsync(cavm.Ans);

            var player = _context.PlayerTable.FirstOrDefault(p => p.ID == cavm.Ans.PID);
            if (player == null)
            {
                return NotFound();
            }
            player.Points++;
            //Update player on playertable
            _context.PlayerTable.Update(player);
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Profile", player);
        }
    }
}
