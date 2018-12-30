

using System.Threading.Tasks;
using NUnit.Framework;
using FizzWare.NBuilder;
using GameOfDrones.Models.Entities;
using GameOfDrones.Models.Services;
using GameOfDrones.Models;
using Microsoft.EntityFrameworkCore;
using GameOfDrones.Models.DataServices;

namespace GameOfDrones.Tests.Integration
{

    public class DataServiceTest
    {

        private GameOfDronesDbContext context;
        
        [SetUp]
        public void SetUp()
        {
              var connection = @"Server=172.17.0.2,1433;
                                Database=GameOfDrones;
                                User Id=sa;Password=root#123;";
            var optionsBuilder = new DbContextOptionsBuilder<GameOfDronesDbContext>();
            optionsBuilder.UseSqlServer(connection);
            this.context = new GameOfDronesDbContext(optionsBuilder.Options);
            
            
        }
        [Test]
        public void TestMustInsertGameAsync()
        {
            var rounds = Builder<Round>.CreateListOfSize(3)
                                        .All()
                                        .With(r => r.Id = 0)
                                        .Build();
            var game = Builder<Game>.CreateNew()
                                    .With(g => g.Rounds = rounds)
                                    .And(g => g.Id = 0).Build();
            var service = new DataService<Game>();
            var result = service.Create(game).Result;
            Assert.AreEqual(game.PlayerOneName, result.PlayerOneName);
            Assert.AreNotEqual(result.Id, 0);
            foreach (var round in result.Rounds)
            {
                Assert.AreNotEqual(round.Id, 0);
            }
            

        }

        [TearDown]
        public void TearDown()
        {
            this.context.RemoveRange(this.context.Games);
            this.context.SaveChangesAsync();
        }
    }

}