using NSubstitute;
using NUnit.Framework;
using FluentAssertions;
using Source.Scripts.Data;
using Source.Scripts.Services.Pause;
using UnityEngine;

namespace Tests.EditMode
{
    public class EditorTests
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

        [Test]
        public void WhenGamePauseOn_AndPaused_ThenIsGameOnPauseTrue()
        {
            // Arrange.
            IGamePauseService gamePause = new GamePause();

            // Act.
            gamePause.On();
            // Assert.
            gamePause.IsGameOnPause.Should().Be(true);
        }
    }
}
