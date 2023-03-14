using System.Collections;
using FluentAssertions;
using NUnit.Framework;
using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Tests.PlayMode
{
    public class MoveTest
    {
        [Test(ExpectedResult = (IEnumerator) null)]
        public IEnumerator WhenDeltaXIsPositive_AndWaitForNextFrame_ThenPositionIsGreaterThanZeroFrame()
        {
            // Arrange.
            PlayerMove playerMove = Create.PlayerMove();
            float xPos = Setup.Input(playerMove, 1);
            
            // Act.
            yield return null;
            
            // Assert.
            playerMove.transform.position.x.Should().BeGreaterThan(xPos);
            Object.Destroy(playerMove.gameObject);
        }
        
        [Test(ExpectedResult = (IEnumerator) null)]
        public IEnumerator WhenDeltaXIsNegative_AndWaitForNextFrame_ThenPositionIsLessThanZeroFrame()
        {
            // Arrange.
            PlayerMove playerMove = Create.PlayerMove();
            float xPos = Setup.Input(playerMove, -1);
            
            // Act.
            yield return null;
            
            // Assert.
            playerMove.transform.position.x.Should().BeLessThan(xPos);
            Object.Destroy(playerMove.gameObject);
        }
        
        [Test(ExpectedResult = (IEnumerator) null)]
        public IEnumerator WhenDeltaXIsZero_AndWaitForNextFrame_ThenPositionIsSameAsZeroFrame()
        {
            // Arrange.
            PlayerMove playerMove = Create.PlayerMove();
            Setup.Input(playerMove, 0);
            
            // Act.
            yield return null;
            
            // Assert.
            playerMove.transform.position.x.Should().Be(0);
        }
    }
}