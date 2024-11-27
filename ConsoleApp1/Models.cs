using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Ticker
    {
        public int id { get; set; }
        [Column("ticker")]
        public string tickerSym { get; set; }
        public List<Price> prices { get; set; }
    }
    public class Price
    {
        public int id { get; set; }
        public int tickerId { get; set; }
        public Ticker tickerSymPrices { get; set; }
        public double price { get; set; }
        public DateTime date { get; set; }
    }
    public class TodaysCondition
    {
        public int id { get; set; }
        public int tickerId { get; set; }
        public string state { get; set; }
        public Ticker tickerSymConditions { get; set; }
    }
}