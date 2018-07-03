using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funemployment.Data;
using Funemployment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Funemployment.Controllers
{
    public class BehavioralController : Controller
    {
        private FunemploymentDbContext _context;

        public BehavioralController(FunemploymentDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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