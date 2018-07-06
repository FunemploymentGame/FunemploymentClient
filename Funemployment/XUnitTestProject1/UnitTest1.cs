using Funemployment.Data;
using Funemployment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        //[Fact]
        //        public async void DbCanSave()
        //        {
        //            DbContextOptions<FunemploymentDbContext> options = new DbContextOptionsBuilder<FunemploymentDbContext>()
        //                .UseInMemoryDatabase("DbCanSave")
        //                .Options;

        //            using (FunemploymentDbContext context = new FunemploymentDbContext(options))
        //            {
        //                Funemployment.Models.Player player = new Funemployment.Models.Player();
        //                player.Username = "testName";
        //                player.Location = "testPlace";
        //                player.About = "testAbout";

        //                await context.PlayerTable.AddAsync(player);
        //                await context.SaveChangesAsync();

        //                var results = context.PlayerTable.Where(person => person.Username == "testName");


        //                Assert.Equal(1, results.Count());
        //            }
        //        //}
        //    //}
        //}


        [Fact]
        public void UserNameWorks()
        {
            Player player = new Player();
            player.Username = "testUser";
            player.Location = "testLocation";
            player.About = "testAbout";

            Assert.Equal("testUser", player.Username);
            Assert.Equal("testLocation", player.Location);
            Assert.Equal("testAbout", player.About);

        }

    }
}
