using GameOfDrones.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GameOfDrones.Models
{
    public class GameOfDronesDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasMany(g => g.Rounds).WithOne(r => r.Game);
        }
        private const string CONNSTRING = @"Server=172.17.0.2,1433;
                                Database=gameofdrones;
                                User Id=sa;
                                Password=root#123;";
        
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseSqlServer(CONNSTRING);
        public GameOfDronesDbContext(): base() {}
        public GameOfDronesDbContext(DbContextOptions<GameOfDronesDbContext> options)
            : base(options)
        { }

        public DbSet<Game> Games { get; set; }

    }

}
