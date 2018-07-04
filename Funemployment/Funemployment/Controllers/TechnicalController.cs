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
        return View();
      }
    }

    [HttpGet]
    public async Task<IActionResult> GetOneTQ(int? id)
    {
      if (id.HasValue)
      {
        return View(await OneTQViewModel.FromIDAsync(id.Value, _context));
      }
      return NoContent();
    }

    [HttpGet]
    public IActionResult CreateAnswer(int id)
    {
      CreateAnswerViewModel cavm = new CreateAnswerViewModel();
      cavm.Ans = new Answer();
      cavm.ID = id;
      return View(cavm);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnswer(CreateAnswerViewModel cavm)
    {
      cavm.Ans.TQID = cavm.ID;
      await _context.AnswerTable.AddAsync(cavm.Ans);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }
  }
}