using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace MatchingApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Get Data
            string fileName = "JsonFiles/input.json";
            using FileStream openStream = File.OpenRead(fileName);
            var deserializeOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            RootObject input = await JsonSerializer.DeserializeAsync<RootObject>(openStream, deserializeOptions);

            // Processing Data
            var matchingLogics = new MatchingLogics();
            var outputMatchingData = new List<Order>();
            foreach (var order in input.Orders)
            {
                outputMatchingData = matchingLogics.MatchingData(outputMatchingData, order);
            }

            // Converting to Market Section data and grouping
            var marketSections = matchingLogics.MarketSections(outputMatchingData);
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            // Display data
            string jsonOutput = JsonSerializer.Serialize(marketSections, serializeOptions);
            Console.WriteLine(jsonOutput);
            Console.ReadLine();
        }
    }
}
