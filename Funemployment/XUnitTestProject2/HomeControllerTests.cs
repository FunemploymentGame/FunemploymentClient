using Funemployment.Controllers;
using Funemployment.Data;
using Funemployment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject2
{
    public class HomeControllerTests
    {
        private readonly IConfiguration Configuration;

        [Fact]
        public void HomeReturnsIActionResult()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("HomeIndexReturns")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                HomeController hc = new HomeController(context, Configuration);

                var x = hc.Index();


                Assert.IsAssignableFrom<IActionResult>(x);
            }

        }

        [Fact]
        public void HomeIndexRedirectsWorks()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("HomeIndexRedirects")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                HomeController hc = new HomeController(context, Configuration);

                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                var x = hc.Index(player.Username);


                Assert.IsType<RedirectToActionResult>(x);
            }

        }

    //    [Fact]
    //    public void BackToProfileWorks()
    //    {

    //        DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    //.UseInMemoryDatabase("BackToProfileRedirects")
    //.Options;

    //        using (FunemploymentDbContext context = new FunemploymentDbContext(options))
    //        {
    //            HomeController hc = new HomeController(context, Configuration);

    //            Player player = new Player();
    //            player.Username = "testUser";
    //            player.Location = "testLocation";
    //            player.About = "testAbout";

    //            var x = hc.BackToProfile();


    //            Assert.IsType<RedirectToActionResult>(x);
    //        }

    //    }
    }
}
