﻿using System;
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

        /// <summary>
        /// Profile view
        /// </summary>
        /// <param name="player">The player</param>
        /// <returns>the view</returns>
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

        /// <summary>
        /// Creates a new player with the user input data, saves to DB and saves ID to cookie
        /// </summary>
        /// <param name="player">A player</param>
        /// <returns>the profile index view</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Player player)
        {
            await _context.PlayerTable.AddAsync(player);
            await _context.SaveChangesAsync();

            // Make sure that the player object is not null. If it is not, 
            // then set the id of the player to the key/value pair ofthe cookie. 
            if (player != null)
            {
                //Response is a part of hte Controller Base and is a part of the 
                // HttpResposne object. 
                // Append means we get to "add" a new cookie
                Response.Cookies.Append("Player", player.ID.ToString());

            }
            return RedirectToAction("Index", player);
        }

        /// <summary>
        /// Show all users by points descending (highscore)
        /// </summary>
        /// <returns>view with list of players</returns>
        public IActionResult ShowAll()
        {
            var players = _context.PlayerTable.Select(s => s).OrderByDescending(p => p.Points).ToList();
            return View(players);
        }

        /// <summary>
        /// Finds a player in playertable by its id and redirects to Index view
        /// </summary>
        /// <param name="id">Id of a single user</param>
        /// <returns>Index view with a player</returns>
        public IActionResult ShowOne(int id)
        {
            var player = _context.PlayerTable.FirstOrDefault(p => p.ID == id);
            return RedirectToAction("Index", "Profile", player);
        }
    }
}