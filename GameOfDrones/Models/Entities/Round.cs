

namespace GameOfDrones.Models.Entities
{
    public class Round 
    {
        public int Id { get; set; }
        public string PlayerOneChoice { get; set; }
        public string PlayerTwoChoice { get; set; }
        public string RoundWinner { get; set; }
    }
}