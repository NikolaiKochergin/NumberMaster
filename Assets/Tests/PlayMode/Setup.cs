using NSubstitute;
using Source.Scripts.Data;
using Source.Scripts.Infrastructure.States;
using Source.Scripts.InteractiveObjects.Number;
using Source.Scripts.PlayerLogic;
using Source.Scripts.Services.Input;
using Source.Scripts.Services.StaticData;

namespace Tests.PlayMode
{
    public class Setup
    {
        public static float Input(PlayerMove playerMove, float value)
        {
            IInputService inputService = Substitute.For<IInputService>();
            IStaticDataService staticData = Substitute.For<IStaticDataService>();
            inputService.DeltaX.Returns(value);

            playerMove.Construct(inputService, staticData);
            float xPos = playerMove.transform.position.x;
            return xPos;
        }

        public static PlayerProgress Player(Player player, int numberValue)
        {
            PlayerProgress progress = new PlayerProgress();
            progress.PlayerStats.StartNumber = numberValue;
            progress.PlayerState.CurrentNumber = numberValue;
            IGameStateMachine stateMachine = Substitute.For<IGameStateMachine>();
            IInputService inputService = Substitute.For<IInputService>();
            IStaticDataService staticData = Substitute.For<IStaticDataService>();
            player.PlayerMove.Construct(inputService, staticData);
            player.ActorFail.Construct(stateMachine);
            return progress;
        }

        public static void Number(EnemyNumber number, Player player, PlayerProgress progress, int numberValue)
        {
            number.Construct(player.PlayerNumber);
            number.Initialize(numberValue);
            player.LoadProgress(progress);
        }
    }
}