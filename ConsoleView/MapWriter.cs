using System;
using System.Text;

namespace ConsoleView
{
    public class MapWriter
    {
        public void Write(bool[,] mapState)
        {
            Console.Clear();
            var xSize = mapState.GetLength(0);
            var ySize = mapState.GetLength(1);
            for (var x = 0; x < xSize; x++)
            {
                var row = new StringBuilder(ySize);
                for (var y = 0; y < ySize; y++)
                {
                    row.Append(mapState[x, y] ? "o " : "  ");
                }

                Console.WriteLine(row);
            }
        }
    }
}