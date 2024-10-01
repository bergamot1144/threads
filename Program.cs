using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Данные о температуре для каждого города (7 дней)
    static string[] cities = { "Киев", "Одесса", "Харьков", "Львов", "Днепр", "Запорожье", "Винница", "Полтава", "Чернигов", "Ивано-Франковск" };
    static int[,] temperatures = new int[10, 7]
    {
        { 20, 21, 19, 22, 20, 18, 21 }, // Киев
        { 25, 27, 24, 23, 26, 28, 29 }, // Одесса
        { 17, 16, 15, 14, 13, 18, 19 }, // Харьков
        { 22, 21, 20, 19, 23, 22, 21 }, // Львов
        { 30, 31, 29, 28, 32, 33, 34 }, // Днепр
        { 28, 27, 26, 25, 24, 23, 22 }, // Запорожье
        { 21, 20, 22, 23, 21, 20, 19 }, // Винница
        { 16, 17, 18, 16, 15, 19, 20 }, // Полтава
        { 19, 18, 20, 19, 17, 16, 15 }, // Чернигов
        { 24, 25, 23, 22, 26, 27, 28 }  // Ивано-Франковск
    };

    static async Task Main()
    {
        
        Task[] tasks = new Task[cities.Length];

        for (int i = 0; i < cities.Length; i++)
        {
            int cityIndex = i; 
            tasks[i] = ProcessCityTemperaturesAsync(cityIndex); 
        }

        
        await Task.WhenAll(tasks);

        Console.WriteLine("\nОбработка завершена.");
    }

    
    static async Task ProcessCityTemperaturesAsync(int cityIndex)
    {
        int[] cityTemperatures = new int[7];
        for (int i = 0; i < 7; i++)
        {
            cityTemperatures[i] = temperatures[cityIndex, i];
        }

        
        double averageTemperature = GetAverageTemperature(cityTemperatures);
        
        int minTemperature = GetMinTemperature(cityTemperatures);
        int maxTemperature = GetMaxTemperature(cityTemperatures);

        
        await Task.Delay(1000); 

        
        Console.Write($"Город: {cities[cityIndex]}, ");
        await Task.Delay(1000); 
        Console.Write($"Средняя температура: {averageTemperature:F2}, ");
        await Task.Delay(1000); 
        Console.Write($"Максимальная температура: {maxTemperature}, ");
        await Task.Delay(1000); 
        Console.WriteLine($"Минимальная температура: {minTemperature}");
    }

    
    static double GetAverageTemperature(int[] temperatures)
    {
        int sum = 0;
        foreach (int temp in temperatures)
        {
            sum += temp;
        }
        return (double)sum / temperatures.Length;
    }

    
    static int GetMinTemperature(int[] temperatures)
    {
        int min = temperatures[0];
        foreach (int temp in temperatures)
        {
            if (temp < min)
            {
                min = temp;
            }
        }
        return min;
    }

    
    static int GetMaxTemperature(int[] temperatures)
    {
        int max = temperatures[0];
        foreach (int temp in temperatures)
        {
            if (temp > max)
            {
                max = temp;
            }
        }
        return max;
    }
}
