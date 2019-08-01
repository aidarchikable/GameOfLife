using System;
using Core;

namespace PerformanceChecker
{
    internal class Program
    {
        private static void Main()
        {
            var dayCounter = 0;
            try
            {
                // ToDo add profiler
                var mapGenerator = new MapGenerator();
                // My goal is map which size is 100000 x 100000
                var map = mapGenerator.GetMap(4000);

                var tempDate = DateTime.UtcNow;
                using (var enumerator = map.Run().GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Console.WriteLine($"{DateTime.UtcNow - tempDate:g} - Memory size: {GC.GetTotalMemory(false):0,000,000,000} bytes");
                        // Temporary way to profile performance
                        tempDate = DateTime.UtcNow;
                        dayCounter++;
                    }
                }
            
                Console.WriteLine($"The End. Days: {dayCounter}");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine($"Out of memory after {dayCounter} days");
                Console.WriteLine($"Memory size: {GC.GetTotalMemory(false):0,000,000,000} bytes");
                
                Environment.Exit(0);
            }
        }
    }
}