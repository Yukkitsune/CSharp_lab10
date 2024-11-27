using Functions;
using marketContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    internal class App
    {
        static async Task Main(string[] args)
        {
            using (var db = new MarketContext())
            {
                var marketFuncs = new MarketFunctions(db);
                Console.Write("Input ticker (e.g. AACG): ");
                string ticker = Console.ReadLine();
                string startDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                string endDate = DateTime.Now.ToString("yyyy-MM-dd");
                Console.WriteLine($"Awaiting data for {ticker} from {startDate} to {endDate}...");
                await marketFuncs.GetDataAndSaveAsync(ticker, startDate, endDate);
                Console.WriteLine("Analyzing stocks...");
                await marketFuncs.AnalyzeData();
                var condition = db.todaysConditions
                    .FirstOrDefault(tc => tc.tickerSymConditions.tickerSym == ticker);
                if (condition != null)
                {
                    Console.WriteLine($"State of stock {ticker}: {condition.state}");
                }
                else
                {
                    Console.WriteLine($"Not enough data for ticker {ticker}");
                }
            }
        }
    }
}