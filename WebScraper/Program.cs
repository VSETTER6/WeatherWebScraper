using HtmlAgilityPack;
using System;
using System.Dynamic;
using System.Net.Http;

namespace WeatherWebScraper
{
    class Program
    {
        static void Main(String[] args)
        {
            // Send get request to wearther.com
            String url = "https://weather.com/sv-SE/weather/today/l/4cdb642d5fce52b92bfb0f723020d9336fded33d996eebf48b5136f06c117487";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get location
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var location = locationElement.InnerText.Trim();
            Console.WriteLine("Location: " + location);

            // Get temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature: " + temperature);

            // Get conditions
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var condition = conditionElement.InnerText.Trim();
            Console.WriteLine("Condition: " + condition);
        }
    }
}