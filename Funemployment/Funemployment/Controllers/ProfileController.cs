using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funemployment.Data;
using Funemployment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Funemployment.Controllers
{
  public class ProfileController : Controller
  {

    private FunemploymentDbContext _context;

    public ProfileController(FunemploymentDbContext context)
    {
      _context = context;
    }

    public IActionResult Index(Player player)
    {
      return View(player);
    }

    [HttpGet]
    public IActionResult Create()
    {
      
      // Add logic to check Db for same username
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Player player)
    {
      await _context.PlayerTable.AddAsync(player);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index");
    }




  }
}