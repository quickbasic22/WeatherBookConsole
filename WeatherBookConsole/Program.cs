using System;

namespace WeatherBookConsole
{
    public class Program
    {
        public static void Main()
        {
            new CSVGenerator<Book>(BookData.Books).Generate();
            new CSVGenerator<Weather>(WeatherData.Weather).Generate();
            Console.ReadKey();
        }
    }
}
