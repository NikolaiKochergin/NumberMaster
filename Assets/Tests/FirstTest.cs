using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using Source.Scripts.Data;
using UnityEngine.TestTools;

namespace Tests
{
    public class FirstTest
    {
        [Test]
        public void WhenIAPService_AndAddIncomingPurchase_ThenIncomingShouldBe1()
        {
            // Arrange.

            // Act.

            // Assert.
            PlayerProgress playerProgress = null;
            playerProgress.PurchaseData.IncomeLevelCount.Should().Be(1);
        }
    }
}
