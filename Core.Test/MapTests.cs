using NUnit.Framework;

namespace Core.Test
{
    public class MapTests
    {
        private bool[,] _map;

        public MapTests()
        {
            _map = new bool[,]
            {
                {false, false, false},
                {true, true, true},
                {false, false, false}
            };
        }

        [Test]
        public void NextDayTest()
        {
            Assert.Fail();
        }
    }
}