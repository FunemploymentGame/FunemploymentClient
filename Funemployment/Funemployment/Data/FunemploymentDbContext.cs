using Funemployment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Funemployment.Data
{
    public class FunemploymentDbContext : DbContext
    {
        public FunemploymentDbContext(DbContextOptions<FunemploymentDbContext> options) : base(options)
        {

        }
        public DbSet<Player> PlayerTable { get; set; }
        public DbSet<Answer> AnswerTable { get; set; }
    }
}
