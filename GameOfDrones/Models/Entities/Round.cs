

using System.ComponentModel.DataAnnotations;

namespace GameOfDrones.Models.Entities
{
    public class Round 
    {
        [Key]
        public int Id { get; set; }
        public string PlayerOneChoice { get; set; }
        public string PlayerTwoChoice { get; set; }
        public string RoundWinner { get; set; }
        public int GameId { get; set;}
        public Game Game { get; set; }
    }
}