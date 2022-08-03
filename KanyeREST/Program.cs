// See https://aka.ms/new-console-template for more information


using Newtonsoft.Json.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        var kanyeURL = "https://api.kanye.rest";
        var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
        var client = new HttpClient();

        Console.WriteLine("Enter your Weather Key");
        var weatherKey = Console.ReadLine();

        var weatherCall = $"https://api.openweathermap.org/data/2.5/weather?lat=30.2672&lon=-97.7431&appid={weatherKey}&units=imperial";

        var weatherResponse = client.GetStringAsync(weatherCall).Result;

        //Console.WriteLine(weatherResponse);

        var weatherVals = JObject.Parse(weatherResponse).GetValue("main").ToString();

        Console.WriteLine(weatherVals);

        for (int i = 0; i < 6; i++)
        {
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var swansonResponse = client.GetStringAsync(swansonURL).Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            var swansonQuote = JArray.Parse(swansonResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim(); ;

            Console.WriteLine($"Kanye:   {kanyeQuote}");
            Console.WriteLine($"Swanson: {swansonQuote}");
        }


    }
}