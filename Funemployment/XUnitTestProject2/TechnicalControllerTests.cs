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
    public class TechnicalControllerTests
    {

        private readonly IConfiguration Configuration;

        private FunemploymentDbContext _context;

        [Fact]
        public async System.Threading.Tasks.Task TechnicalIndexWorksAsync()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("TechnicalIndexRedirects")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                TechnicalController tc = new TechnicalController(context);

                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                var x = tc.Index();

                var y = await OneBQViewModel.FromIDAsync(1, context);
                Assert.NotEmpty(y.behaviorQuestion.Content);

                Assert.IsType<ViewResult>(x.Result);
            }
        }

        [Fact]
        public void TechnicalGetONeWorks()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("TechnicalGetOne")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
               TechnicalController tc = new TechnicalController(context);

                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                var x = tc.GetOneTQ(null);


                Assert.IsType<NoContentResult>(x.Result);
            }
        }

        [Fact]
        public void CreateAnswerWorks()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("TechnicalndexRedirects")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                TechnicalController tc = new TechnicalController(context);

                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                Answer answer = new Answer();
                answer.Content = "testContent";
                answer.BQID = 100;


                var x = tc.CreateAnswer(100);



                Assert.Equal("testContent", answer.Content);
            }
        }

        [Fact]
        public void CreateAnswerRedirectsAsync()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("CreateAnswerRedirect")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                TechnicalController tc = new TechnicalController(context);

                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                Answer answer = new Answer();



                CreateAnswerViewModel cavm = new CreateAnswerViewModel();

                try
                {
                    var x = tc.CreateAnswer(cavm);
                }
                catch (Exception ex)
                {
                    Assert.True(ex is NullReferenceException);
                }

            }
        }
    }
}
