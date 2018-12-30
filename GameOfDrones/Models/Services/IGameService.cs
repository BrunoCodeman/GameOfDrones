

using GameOfDrones.Models.Entities;

namespace GameOfDrones.Models.Services
{

    public interface IGameService
    {
        Game ExecuteRound(Game game);
        Game SetWinner(Game game);
        
    }
    
}