using System;
using Core;

namespace PerformanceChecker
{
    internal class Program
    {
        private static void Main()
        {
            // ToDo add profiler
            var mapGenerator = new MapGenerator();
            // My goal is map which size is 100000 x 100000
            var map = mapGenerator.GetMap(3000);

            var dayCounter = 0;
            var tempDate = DateTime.UtcNow;
            using (var enumerator = map.Run().GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine($"{DateTime.UtcNow - tempDate:g}");
                    // Temporary way to profile performance
                    tempDate = DateTime.UtcNow;
                    dayCounter++;
                }
            }
            
            Console.WriteLine($"The End. Days: {dayCounter}");
        }
    }
}