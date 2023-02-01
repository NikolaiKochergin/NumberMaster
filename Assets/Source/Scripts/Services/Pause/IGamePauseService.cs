namespace Source.Scripts.Services.Pause
{
    public interface IGamePauseService : IService
    {
        bool IsGameOnPause { get; }
        void On();
        void Off();
    }
}