using NSubstitute;
using NUnit.Framework;
using FluentAssertions;
using Source.Scripts.Data;

namespace Tests.EditMode
{
    public class DirectionTests
    {
        [Test]
        public void WhenStoringItem_AndInventoryIsEmpty_ThenItemCountShouldBe1()
        {
            // Arrange.
            PlayerProgress progress = new PlayerProgress();

            // Act.
            progress.PlayerStats.StartNumber = 1;

            // Assert.
            progress.PlayerStats.StartNumber.Should().Be(1);
        }
    }
}
