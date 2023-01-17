using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services;
using Source.Scripts.Services.Input;
using UnityEngine;

namespace Source.Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;
        public static IInputService InputService;

        public Game()
        {
            RegisterInputService();
        }

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);   
        }

        private void RegisterInputService()
        {
            if (Application.isEditor)
                InputService = new StandaloneInputService();
            else
                InputService = new MobileInputService();
        }
    }
}
