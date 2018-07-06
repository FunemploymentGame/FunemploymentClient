using Funemployment.Controllers;
using Funemployment.Data;
using Funemployment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class ProfileControllerTests
    {
        [Fact]
        public async void DbCanSave()
        {
            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
                .UseInMemoryDatabase("DbCanSave")
                .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                Funemployment.Models.Player player = new Funemployment.Models.Player();
                player.Username = "testName";
                player.Location = "testPlace";
                player.About = "testAbout";

                await context.PlayerTable.AddAsync(player);
                await context.SaveChangesAsync();

                var results = context.PlayerTable.Where(person => person.Username == "testName");


                Assert.Equal(1, results.Count());
            }
        }


        private readonly IConfiguration Configuration;

        [Fact]
        public void ProfileControllerCanCreate()
        {
            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("PCCreates")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                ProfileController pc = new ProfileController(context, Configuration);

                var x = pc.Create(player);

                var results = context.PlayerTable.Where(p => p.Username == "testUser");

                Assert.Equal(1, results.Count());
            }

        }

        [Fact]
        public void UserNameLocationAboutWorks()
        {
            Player player = new Player();
            player.Username = "testUser";
            player.Location = "testLocation";
            player.About = "testAbout";

            Assert.Equal("testUser", player.Username);
            Assert.Equal("testLocation", player.Location);
            Assert.Equal("testAbout", player.About);

        }

        [Fact]
        public void ShowOneandShowAllReturnsIActionResult()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("ShowAllReturns")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                ProfileController pc = new ProfileController(context, Configuration);

                var x = pc.ShowAll();
                var y = pc.ShowOne(player.ID);


                Assert.IsAssignableFrom<IActionResult>(x);
                Assert.IsAssignableFrom<IActionResult>(y);
            }

        }


        [Fact]
        public void PlayerAllAnswersReturnsIActionResult()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("AllResultsReturns")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                ProfileController pc = new ProfileController(context, Configuration);

                var x = pc.PlayerAllAnswers(player.ID);


                Assert.IsType<RedirectToActionResult>(x.Result);
            }

        }


        [Fact]
        public void ErrorReturnsIActionResult()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("ShowAllReturns")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                ProfileController pc = new ProfileController(context, Configuration);

                var x = pc.Error(player.ID);


                Assert.IsAssignableFrom<IActionResult>(x);
            }

        }

    }
}

