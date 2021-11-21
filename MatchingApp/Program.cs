using System;
using System.Collections.Generic;

namespace MatchingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Seeding Data
            var input = new List<Order>
            {
                new Order{ Command = "sell", Price = 100.003, Amount = 2.4},
                new Order{ Command = "buy", Price = 90.394, Amount = 3.445},
                new Order{ Command = "buy", Price = 89.394, Amount = 4.3},
                new Order{ Command = "sell", Price = 100.013, Amount = 2.2},
                new Order{ Command = "buy", Price = 90.15, Amount = 1.305},
                new Order{ Command = "buy", Price = 90.394, Amount = 1.0},
                new Order{ Command = "sell", Price = 90.394, Amount = 2.2},
                new Order{ Command = "sell", Price = 90.15, Amount = 3.4},
                new Order{ Command = "buy", Price = 91.33, Amount = 1.8},
                new Order{ Command = "buy", Price = 100.01, Amount = 4.0},
                new Order{ Command = "sell", Price = 100.015, Amount = 3.8},
            };

            var matchingLogics = new MatchingLogics();

            // Processing Data
            var output = new List<Order>();
            foreach (var order in input)
            {
                output = matchingLogics.MatchingData(output, order);
            }

            // Converting to Market Section data and grouping
            var marketSections = new List<MarketSection>();
            marketSections = matchingLogics.MarketSections(output);

            // Display data
            foreach (var order in marketSections)
            {
                Console.WriteLine(order.Section + "-----" + order.Price + "-----" + order.Volume);
            }
            Console.ReadLine();
        }
    }
}
