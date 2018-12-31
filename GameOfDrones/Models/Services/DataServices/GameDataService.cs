using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameOfDrones.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameOfDrones.Models.DataServices
{
    public class GameDataService : DataService<Game>
    {
        public GameDataService():base(){}

        public new async Task<ICollection<Game>> Read(Func<Game, bool> func)
        {
            var ctx = this.GetContext();
            return ctx.Games.Include(g => g.Rounds).Where(func).ToList<Game>();
            // var res = await new Task<ICollection<Game>>(()=> ctx.Games.Include(g => g.Rounds)
            //                                             .Where(func).ToList<Game>());
            // res.First().Rounds = 
            // ctx.Set<Round>().Where(r=>r.GameId == res.First().Id).ToList();
            // return res;
        }

    }
}