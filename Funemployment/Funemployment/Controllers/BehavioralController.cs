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
    public class BehavioralController : Controller
    {
        private FunemploymentDbContext _context;

        public BehavioralController(FunemploymentDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
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
                return View();
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            // add logic to check db for same username
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Answer answer)
        {
            await _context.AnswerTable.AddAsync(answer);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}