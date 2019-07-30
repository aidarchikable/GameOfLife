using System;
using System.Threading;
using Core;

namespace ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapWriter = new MapWriter();
            var mapGenerator = new MapGenerator();
            var map = mapGenerator.GetMap(20);
            
            while (true)
            {
                mapWriter.Write(map.Current);
                map.NextDay();
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}