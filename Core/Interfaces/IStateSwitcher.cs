namespace Assets.CodeBase.Core
{
    public interface IStateSwitcher
    {
        public void SwitchState<TState>() where TState : IState;
    }
}
