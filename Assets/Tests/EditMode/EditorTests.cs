using NUnit.Framework;
using FluentAssertions;
using Source.Scripts.Data;
using Source.Scripts.Services.IAP;
using Source.Scripts.Services.Pause;
using Source.Scripts.Services.PersistentProgress;
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

        [Test]
        public void WhenBuyStartLevel_AndStartLevelIs0_ThenStartLevelShouldBe1()
        {
            // Arrange.
            IPersistentProgressService progressService = Setup.IAPService(out IAPService iapService, PurchaseType.StartLevel);

            // Act.
            iapService.Buy(PurchaseType.StartLevel);
            
            // Assert.
            progressService.Progress.PurchaseData.StartNumberCount.Should().Be(1);
        }

        [Test]
        public void WhenBuyIncomingLevel_AndIncomingLevelIs0_ThenIncomingLevelShouldBe1()
        {
            // Arrange.
            IPersistentProgressService progressService = Setup.IAPService(out IAPService iapService, PurchaseType.Incoming);

            // Act.
            iapService.Buy(PurchaseType.Incoming);

            // Assert.
            progressService.Progress.PurchaseData.IncomeLevelCount.Should().Be(1);
        }
    }
}
