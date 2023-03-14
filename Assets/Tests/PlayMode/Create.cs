using Source.Scripts.InteractiveObjects.Number;
using Source.Scripts.PlayerLogic;
using UnityEngine;

namespace Tests.PlayMode
{
    public class Create
    {
        public static PlayerMove PlayerMove()
        {
            PlayerMove playerMove = new GameObject().AddComponent<PlayerMove>();
            return playerMove;
        }

        public static Player Player(Vector3 position)
        {
            Player playerPrefab = Resources.Load<Player>("Player/Player");
            Player player = Object.Instantiate(playerPrefab, position, Quaternion.identity);
            return player;
        }

        public static EnemyNumber EnemyNumber(Vector3 position)
        {
            EnemyNumber numberPrefab = Resources.Load<EnemyNumber>("Enemies/EnemieNumber");
            EnemyNumber number = Object.Instantiate(numberPrefab, position, Quaternion.identity);
            return number;
        }
    }
}