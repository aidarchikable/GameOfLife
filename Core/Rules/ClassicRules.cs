namespace Core.Rules
{
    public interface IRules
    {
        bool IsAlive(int neighborsCount);
    }

    public class ClassicRules : IRules
    {
        public bool IsAlive(int neighborsCount) => neighborsCount >= 2 && neighborsCount <= 3;
    }
}