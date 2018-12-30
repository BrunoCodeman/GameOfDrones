using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameOfDrones.Models.Entities;
using GameOfDrones.Models.Services;
using GameOfDrones.Models.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace GameOfDrones.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private IDataService<Game> dataService;
        private IGameService gameService;
        public GameController(IDataService<Game> ds, IGameService gs)
        {
            this.gameService = gs;
            this.dataService =ds;
        }
    
        [HttpGet("[action]")]
        public async Task<ICollection<Game>> GetGame(int gameID)
        {
            return await this.dataService.Read(g => g.Id == gameID);
        }

        [HttpPost("[action]")]
        public async Task<Game> PostGame([FromBody]Game game)
        {
            return await this.dataService.Create(game);
        }


        [HttpPut("[action]")]
        public async Task<Game> PutGame([FromBody]Game game)
        {
            var res = this.gameService.ExecuteRound(game);
            return await this.dataService.Update(res);
            
        }

        // [HttpGet("scores")]
        // public async Task<Game> GetScores()
        // {
        //     return ;
        // }

    }
}
