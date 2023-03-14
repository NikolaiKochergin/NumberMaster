using System.Collections;
using Source.Scripts.Data;
using Source.Scripts.InteractiveObjects.Number;
using Source.Scripts.PlayerLogic;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayMode
{
    public class TakeNumberTests
    {
        [UnityTest]
        public IEnumerator WhenPlayerTakeNumber_AndNumberLessThenPlayerNumber_ThenPlayerTakeIt()
        {
            // Arrange.
            Player player = Create.Player(Vector3.zero);
            PlayerProgress progress = Setup.Player(player, 10);

            EnemyNumber number = Create.EnemyNumber(Vector3.zero);
            Setup.Number(number, player, progress, 5);

            // Act.
            Time.timeScale = 1f;
            yield return new WaitForSeconds(0.1f);
            
            // Assert.
            UnityEngine.Assertions.Assert.IsNull(number);
            
            //Tear Down
            Object.Destroy(player.gameObject);
            if(number)
                Object.Destroy(number.gameObject);
        }

        [UnityTest]
        public IEnumerator WhenPlayerTakeNumber_AndNumberGreaterThenPlayerNumber_ThenPlayerNotTakeIt()
        {
            // Arrange.
            Player player = Create.Player(Vector3.forward * 10);
            PlayerProgress progress = Setup.Player(player, 5);

            EnemyNumber number = Create.EnemyNumber(Vector3.forward * 10);
            Setup.Number(number, player, progress, 10);
            
            // Act.
            Time.timeScale = 1f;
            yield return new WaitForSeconds(0.1f);
            
            // Assert.
            UnityEngine.Assertions.Assert.IsNotNull(number);
            
            //Tear Down
            Object.Destroy(player.gameObject);
            if(number)
                Object.Destroy(number.gameObject);
        }
    }
}
