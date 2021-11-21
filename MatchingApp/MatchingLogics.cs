using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingApp
{
    public class MatchingLogics
    {
        /// <summary>
        /// MatchingData method
        /// </summary>
        /// <param name="output">List data after matching</param>
        /// <param name="order">Current order</param>
        /// <returns>List output</returns>
        public List<Order> MatchingData(List<Order> output, Order order)
        {
            if (output.Count == 0)
            {
                output.Add(order);
            }
            else
            {
                var matchedList = new List<Order>();
                if (order.Command == "buy")
                {
                    matchedList = output.Where(x => x.Command != order.Command && x.Price <= order.Price).ToList();
                }
                else
                {
                    matchedList = output.Where(x => x.Command != order.Command && x.Price >= order.Price).ToList();
                }
                if (matchedList.Any())
                {
                    var remainingAmount = order.Amount;
                    foreach (var item in matchedList)
                    {
                        if (item.Amount == remainingAmount)
                        {
                            output.Remove(item);
                            break;
                        }
                        else if (item.Amount > remainingAmount)
                        {
                            // TODO : Must to use Math.Round here to match the output
                            // although I don't think that this is a good idea (especially in finance domain, each number is very important)
                            item.Amount = Math.Round(item.Amount - remainingAmount, 3);
                            item.Price = order.Price;
                            remainingAmount = 0;
                            break;
                        }
                        else if (item.Amount < remainingAmount)
                        {
                            // TODO : Must to use Math.Round here to match the output
                            // although I don't think that this is a good idea (especially in finance domain, each number is very important)
                            remainingAmount = Math.Round(remainingAmount - item.Amount,3);
                            output.Remove(item);
                        }
                    }
                    if (remainingAmount > 0)
                    {
                        order.Amount = remainingAmount;
                        output.Add(order);
                    }
                }
                else
                {
                    output.Add(order);
                }
            }
            return output;
        }

        /// <summary>
        /// Transform to Market Section Data 
        /// Ordering data
        /// </summary>
        /// <param name="orderList">List of current orders after matching</param>
        /// <returns>Buy and Sell section with ordering</returns>
        public MarketSection MarketSections(List<Order> orderList)
        {
            // Converting to Market Section data
            var marketSections = new List<MarketSection>();
            var output = new MarketSection();
            var buySection = orderList.Where(x => x.Command == "buy").GroupBy(x => x.Price).Select(cl => new MarketValue { Price = cl.Key, Volume = cl.Sum(c => c.Amount) }).OrderByDescending(x => x.Price).ToList();
            var sellSection = orderList.Where(x => x.Command == "sell").GroupBy(x => x.Price).Select(cl => new MarketValue { Price = cl.Key, Volume = cl.Sum(c => c.Amount)}).OrderBy(x => x.Price).ToList();
            output.Buy = buySection;
            output.Sell = sellSection;
            return output;
        }
    }
}
