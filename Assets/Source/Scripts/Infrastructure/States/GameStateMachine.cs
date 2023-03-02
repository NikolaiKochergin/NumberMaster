using System;
using System.Collections.Generic;
using Source.Scripts.Infrastructure.Factory;
using Source.Scripts.Services;
using Source.Scripts.Services.Ads;
using Source.Scripts.Services.Analytics;
using Source.Scripts.Services.Leaderboard;
using Source.Scripts.Services.PersistentProgress;
using Source.Scripts.Services.SaveLoad;
using Source.Scripts.Services.Sound;
using Source.Scripts.Services.StaticData;
using Source.Scripts.UI.Services.Factory;
using Source.Scripts.UI.Services.Windows;

namespace Source.Scripts.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader,  AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader,
                    services.Single<IGameFactory>(), 
                    services.Single<IPersistentProgressService>(),
                    services.Single<IStaticDataService>(),
                    services.Single<IUIFactory>(),
                    services.Single<ISoundService>(),
                    services.Single<IAdsService>(),
                    services.Single<IAnalyticService>()),
                
                [typeof(LoadProgressState)] = new LoadProgressState(this, 
                    services.Single<IPersistentProgressService>(),
                    services.Single<IStaticDataService>(),
                    services.Single<ISaveLoadService>()),
                
                [typeof(ShopState)] = new ShopState(
                    services.Single<IWindowService>(),
                    services.Single<ISaveLoadService>()),
                
                [typeof(GameLoopState)] = new GameLoopState(
                    services.Single<IGameFactory>()),
                
                [typeof(LevelCompleteState)] = new LevelCompleteState(this,
                    services.Single<IPersistentProgressService>(),
                    services.Single<IStaticDataService>(),
                    services.Single<ISaveLoadService>(),
                    services.Single<IGameFactory>(),
                    services.Single<IAnalyticService>(),
                    services.Single<ILeaderboardService>()),
                
                [typeof(FailState)] = new FailState(this, sceneLoader,
                    services.Single<IPersistentProgressService>(),
                    services.Single<IStaticDataService>(),
                    services.Single<IAnalyticService>())
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}