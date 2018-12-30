using System.Linq;
using System.Collections.Generic;
using GameOfDrones.Models.Entities;

namespace GameOfDrones.Models.Services
{

    public class GameService : IGameService
    {
        private Dictionary<string,string> gameChoices = new Dictionary<string, string> 
        {{"Rock","Scissor"}, {"Scissor","Paper"} , {"Paper","Rock"}};

        public Game ExecuteRound(Game game)
        {
            if(game.Rounds.Count() <=3)
            {
                var round = game.Rounds.Last();
                round.RoundWinner = "Draw";
                if(gameChoices[round.PlayerOneChoice] == round.PlayerTwoChoice)
                {
                    round.RoundWinner = game.PlayerOneName;
                }
                if(gameChoices[round.PlayerTwoChoice] == round.PlayerOneChoice)
                {
                    round.RoundWinner = game.PlayerTwoName;
                }
                
                game = this.SetWinner(game);
            }

            return game;
        }

        public Game SetWinner(Game game)
        {
            if(game.Rounds.Count() == 3)
            {
                int p1Victories = 0;
                int p2Victories = 0;
                game.GameWinner = "Draw";
                foreach (var round in game.Rounds)
                {
                    if(round.RoundWinner == game.PlayerOneName)
                    {
                        p1Victories+=1;
                    }

                    if(round.RoundWinner == game.PlayerTwoName)
                    {
                        p2Victories+=1;
                    }
                }

                if(p1Victories > p2Victories)
                {
                    game.GameWinner = game.PlayerOneName;
                }

                if(p2Victories > p1Victories )
                {
                    game.GameWinner = game.PlayerTwoName;
                }

            }

            return game;
        }
    }
}