namespace WeatherSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Weather app simulator
            Random random = new Random();
            int inputDays = 0;

            while (inputDays.Equals(0))
            {
                Console.WriteLine("Enter the number of days for the weather forecast: ");
                try
                {
                    inputDays = int.Parse(Console.ReadLine() ?? string.Empty);
                }
                catch (Exception e)
                {
                    Console.WriteLine("You didn't give a valid number\n" + e.Message);
                }
            }

            int[] temperature = new int[inputDays];
            string[] conditions = { "Sunny", "Cloudy", "Rainy", "Snowy" };
            string[] weatherConditions = new string[inputDays];

            Console.WriteLine("");
            Console.WriteLine("Degrees\t\tWeather");

            for (int i = 0; i < inputDays; i++)
            {
                temperature[i] = random.Next(-5, 40);
                weatherConditions[i] = conditions[random.Next(conditions.Length)];
                if (temperature[i] < 0 && weatherConditions[i] == "Rainy") 
                {
                    weatherConditions[i] = "Snowy";
                }
                else if (temperature[i] >= 0 && weatherConditions[i] == "Snowy")
                {
                    weatherConditions[i] = "Rainy";
                }
                    Console.WriteLine(temperature[i] + "\t\t" + weatherConditions[i]);
                Console.WriteLine("");
            }

            Console.WriteLine($"The average temperature is: {AverageTemp(temperature)}");

            Console.WriteLine($"The minumun temperature is: {temperature.Min()}");

            Console.WriteLine($"The maximum temperature is: {temperature.Max()}");

            Console.WriteLine($"The most common condition is: {CommonWeather(weatherConditions)}" );

            Console.ReadKey();
        }

        public static int AverageTemp(int[] temp)
        {
            int sum = 0;
            int average = 0;

            for (int i = 0; i < temp.Length; i++)
            {
                sum += temp[i];
            }
            average = sum / temp.Length;

            return average;
        }

        public static string CommonWeather(string[] weather)
        {
            int count = 0;
            string commonWeather = weather[0];

            for (int i = 0; i < weather.Length; i++)
            {
                int tempCount = 0;
                for (int j = 0; j < weather.Length; j++)
                {
                    if (weather[j] == weather[i])
                    {
                        tempCount++;
                    }
                }

                if (tempCount > count)
                {
                    count = tempCount;
                    commonWeather = weather[i];
                }
            }

            return commonWeather;
        }
    }
}