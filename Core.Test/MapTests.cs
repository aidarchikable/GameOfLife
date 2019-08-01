using System.Linq;
using Core.Rules;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Core.Test
{
    public class MapTests
    {
        [Test]
        public void NextDay_ShouldRotate()
        {
            var firstGeneration = new[,]
            {
                {false, false, false, false, false},
                {false, false, false, false, false},
                {false, true, true, true, false},
                {false, false, false, false, false},
                {false, false, false, false, false}
            };

            var secondGeneration = new Map(firstGeneration, new ClassicRules()).Run().First();
            secondGeneration.Should().BeEquivalentTo(new[,]
            {
                {false, false, false, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, true, false, false},
                {false, false, false, false, false}
            });
        }

        [Test]
        public void EndTheGame_ShouldEndGame()
        {
            var rulesMock = Mock.Of<IRules>(rules => rules.CheckTheEnd(It.IsAny<bool[,]>()));
            var secondGeneration = new Map(new[,] {{true}}, rulesMock).Run().FirstOrDefault();
            secondGeneration.Should().BeNull();
        }

        [Test]
        public void EndTheGame_ShouldContinue()
        {
            var rulesMock = Mock.Of<IRules>(rules =>
                rules.CheckTheEnd(It.IsAny<bool[,]>()) == false
                && rules.IsAlive(It.IsAny<bool>(), It.IsAny<int>()));
            var secondGeneration = new Map(new[,] {{true}}, rulesMock).Run().FirstOrDefault();
            secondGeneration.Should().NotBeNull();
            secondGeneration.Should().BeEquivalentTo(new[,] {{true}});
        }
    }
}