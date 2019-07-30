using System;
using Core.Rules;

namespace Core
{
    public class Map
    {
        private bool[,] _state;
        private int _xLenght;
        private int _yLenght;
        private IRules _rules;

        public Map(bool[,] state, IRules rules)
        {
            _state = state;
            _rules = rules;
            _xLenght = _state.GetLength(0);
            _yLenght = _state.GetLength(1);
        }

        public bool[,] Current => _state;

        public void NextDay()
        {
            var nextState = new bool[_xLenght,_yLenght];
            for (int x = 0; x < _xLenght; x++)
            {
                for (int y = 0; y < _yLenght; y++)
                {
                    nextState[x, y] = _rules.IsAlive(GetNeighborsCount(x, y));
                }    
            }

            _state = nextState;
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
    }
}