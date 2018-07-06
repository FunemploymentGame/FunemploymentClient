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
    public class BehaviorControllerTests
    {

        private readonly IConfiguration Configuration;

        private FunemploymentDbContext _context;

        [Fact]
        public void BehaviorIndexWorks()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("BehaviorIndexRedirects")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                BehavioralController bc = new BehavioralController(context);

                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                var x = bc.Index();


                Assert.IsType<ViewResult>(x.Result);
            }
        }

        [Fact]
        public void BehaviorGetONeWorks()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("BehaviorGetOne")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                BehavioralController bc = new BehavioralController(context);

                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                var x = bc.GetOneBQ(null);


                Assert.IsType<NoContentResult>(x.Result);
            }
        }

        [Fact]
        public void CreateAnswerWorks()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("BehaviorIndexRedirects")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                BehavioralController bc = new BehavioralController(context);

                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                Answer answer = new Answer();
                answer.Content = "testContent";
                answer.BQID = 100;
                

                var x = bc.CreateAnswer(100);



                Assert.Equal("testContent", answer.Content);
            }
        }

        [Fact]
        public async System.Threading.Tasks.Task CreateAnswerRedirectsAsync()
        {

            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
    .UseInMemoryDatabase("CreateAnswerRedirect")
    .Options;

            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
            {
                BehavioralController bc = new BehavioralController(context);

                Player player = new Player();
                player.Username = "testUser";
                player.Location = "testLocation";
                player.About = "testAbout";

                Answer answer = new Answer();
                answer.Content = "testContent";
                answer.BQID = 100;


                var x = bc.CreateAnswer(100);

                CreateAnswerViewModel cavm = new CreateAnswerViewModel();

                await bc.CreateAnswer(cavm);


                Assert.IsType<ViewResult>(x.Result);
            }
        }
    }
}
