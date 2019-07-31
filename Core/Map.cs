using System;
using System.Collections.Generic;
using Core.Rules;

namespace Core
{
    public class Map 
    {
        private bool[,] _state;
        private readonly int _xLenght;
        private readonly int _yLenght;
        private readonly IRules _rules;

        public Map(bool[,] state, IRules rules)
        {
            _state = state;
            _rules = rules;
            _xLenght = _state.GetLength(0);
            _yLenght = _state.GetLength(1);
        }


        private int GetNeighborsCount(int x, int y) =>
            GetCellValue(x-1, y)
            + GetCellValue(x-1, y+1)
            + GetCellValue(x, y+1)
            + GetCellValue(x+1, y+1)
            + GetCellValue(x+1, y)
            + GetCellValue(x+1, y-1)
            + GetCellValue(x, y-1)
            + GetCellValue(x-1, y-1);

        private int GetCellValue(int x, int y) =>
            Convert.ToInt32(_state[(x + _xLenght) % _xLenght, (y + _yLenght) % _yLenght]);

        public IEnumerable<bool[,]> Run()
        {
            while (true)
            {
                var nextState = GenerateNextState();

                if (_rules.CheckTheEnd(nextState))
                {
                    yield break;
                }

                _state = nextState;
                yield return _state;    
            }
        }

        private bool[,] GenerateNextState()
        {
            var nextState = new bool[_xLenght, _yLenght];
            for (int x = 0; x < _xLenght; x++)
            {
                for (int y = 0; y < _yLenght; y++)
                {
                    nextState[x, y] = _rules.IsAlive(_state[x, y], GetNeighborsCount(x, y));
                }
            }

            return nextState;
        }
    }
}