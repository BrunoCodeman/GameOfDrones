

using System.Collections.Generic;

namespace GameOfDrones.Models.Entities
{
    public class Game 
    {

        public Game() => this.Rounds = new List<Round>(){};
        public int Id { get; set; }
        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }
        public ICollection<Round> Rounds { get; set; }
        public string GameWinner { get; set; }
    }
}