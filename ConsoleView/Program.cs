using System;
using System.Threading;
using Core;

namespace ConsoleView
{
    internal class Program
    {
        private static void Main()
        {
            var mapWriter = new MapWriter();
            var mapGenerator = new MapGenerator();
            var map = mapGenerator.GetMap(20);

            var dayCounter = 0;
            foreach (var day in map.Run())
            {
                mapWriter.Write(day);
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
                dayCounter++;
            }

            Console.WriteLine($"The End. Days: {dayCounter}");
        }
    }
}