using System.Linq;
using Moq;
using NUnit.Framework;
using GameOfDrones.Models.Entities;
using FizzWare.NBuilder;
using GameOfDrones.Models.Services;
using System;
using System.Collections.Generic;
using GameOfDrones.Models.DataServices;

namespace GameOfDrones.Tests
{
    public class GameServiceTest
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMustCheckWinner()
        {
            var rounds = Builder<Round>.CreateListOfSize(3)
                                        .All().With(r => r.RoundWinner = "")
                                        .TheFirst(1)
                                        .With(r =>  r.PlayerOneChoice  = "Paper")
                                        .And(r => r.PlayerTwoChoice = "Scissor")
                                        .TheNext(2)
                                        .With(r =>  r.PlayerOneChoice  = "Paper")
                                        .And(r => r.PlayerTwoChoice = "Rock")
                                        .Build();
                                        
            var game = Builder<Game>.CreateNew()
                                    .With(g => g.Rounds = rounds)
                                    .Build();
            var svc = new GameService();
            var res = svc.ExecuteRound(game);
            Assert.AreEqual(game.Rounds.Count(), 3);
            Assert.AreEqual(game.GameWinner, res.PlayerOneName);
            
            
        }
        [Test]
        public void TestMustCheckPlayerOneVictory()
        {
            Tuple<string, string>[]  rounds = { Tuple.Create("Rock", "Scissor"),
                                                Tuple.Create("Scissor","Paper"),
                                                Tuple.Create("Paper","Rock")
                                                };
            var game = Builder<Game>.CreateNew().With(g => g.GameWinner = "").Build();
            
            var svc = new GameService();
            var champion = "";
            foreach (var round in rounds)
            {
                var gameRound = new Round() { PlayerOneChoice = round.Item1, 
                                            PlayerTwoChoice = round.Item2 } ;
                game.Rounds.Add(gameRound);
                var res = svc.ExecuteRound(game);
                var executedRound = res.Rounds.Last();
                Assert.AreEqual(gameRound.PlayerOneChoice, executedRound.PlayerOneChoice);
                champion = res.GameWinner;
            }
            Assert.AreEqual(champion, game.PlayerOneName);
        }

        [Test]
        public void TestMustCheckPlayerTwoVictory()
        {
            Tuple<string, string>[]  rounds = { Tuple.Create("Rock", "Scissor"),
                                                Tuple.Create("Scissor","Paper"),
                                                Tuple.Create("Paper","Rock")
                                                };
            var game = Builder<Game>.CreateNew().Build();
            var svc = new GameService();
            string champion = "";
            foreach (var round in rounds)
            {
                var gameRound = new Round() { PlayerTwoChoice = round.Item1, 
                                            PlayerOneChoice = round.Item2 } ;
                game.Rounds.Add(gameRound);
                var res = svc.ExecuteRound(game);
                var executedRound = res.Rounds.Last();
                Assert.AreEqual(gameRound.PlayerTwoChoice, executedRound.PlayerTwoChoice);
                champion = res.GameWinner;
            }
            Assert.AreEqual(champion, game.PlayerTwoName);
        }
    }
}