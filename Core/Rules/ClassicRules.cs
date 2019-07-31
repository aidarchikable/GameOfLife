using System.Collections.Generic;
using System.Linq;
using Core.Helper;

namespace Core.Rules
{
    public class ClassicRules : IRules
    {
        private readonly List<bool[]> _previousStates;

        public ClassicRules()
        { 
            _previousStates = new List<bool[]>();
        }

        public bool IsAlive(bool currentState, int neighborsCount) 
            => currentState ? neighborsCount >= 2 && neighborsCount <= 3 : neighborsCount == 3;

        public bool CheckTheEnd(bool[,] field)
        {
            var newState = field.Join();
            
            if (CheckIsEmpty(newState))
            {
                return true;
            }
            
            // Because of Any 
            if (_previousStates.Count != 0 && _previousStates.Any(previous => previous.SequenceEqual(newState)))
            {
                return true;
            }
            
            _previousStates.Add(newState);
            return false;
        }

        private bool CheckIsEmpty(bool[] field) => field.All(cell => cell == false);
    }
}