using GameAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameAPI
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Game> Game { get; set; }

        public DbSet<GameUsers> GameUsers { get;set;}
        public DbSet<Movement> Movement{ get;set;}
        public DbSet<Round> Round { get; set; }
        public DbSet<ResultRound> ResultRound { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
    }
}
