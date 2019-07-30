using System;
using Core.Rules;

namespace Core
{
    public class MapGenerator
    {
        private readonly Random _random;
        private const int DefaultTableSize = 100;
        private readonly IRules _rules;
        
        public MapGenerator()
        {
            _rules = new ClassicRules();
            _random = new Random();
        }

        public Map GetMap(uint? size = null)
        {
            var mapSize = size ?? DefaultTableSize;
            var map = new bool[mapSize, mapSize];
            for (int x = 0; x < mapSize; x++)
            {
                for (int y = 0; y < mapSize; y++)
                {
                    map[x, y] = _random.NextDouble() < 0.5;
                }
            }
            return new Map(map, _rules);
        }
    }
}