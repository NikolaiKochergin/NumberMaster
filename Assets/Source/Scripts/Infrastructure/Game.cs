using Source.Scripts.Infrastructure.States;
using Source.Scripts.Services;
using Source.Scripts.Services.Input;
using UnityEngine;

namespace Source.Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);   
        }
    }
}
