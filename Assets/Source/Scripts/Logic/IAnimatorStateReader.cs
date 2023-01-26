namespace Source.Scripts.Logic
{
    internal interface IAnimatorStateReader
    {
        void EnteredState(int stateHash);
        void ExitedState(int stateHash);
        AnimatorState State { get; }
    }
}