namespace Core.Rules
{
    public interface IRules
    {
        bool IsAlive(bool currentState, int neighborsCount);

        bool CheckTheEnd(bool[,] field);
    }
}