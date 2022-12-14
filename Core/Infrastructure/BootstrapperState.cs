namespace Assets.CodeBase.Core
{
    public class BootstrapperState: IState
    {
        private readonly IStateSwitcher _stateSwitcher;

        public BootstrapperState(IStateSwitcher stateSwitcher)
            => _stateSwitcher = stateSwitcher;

        public void Enter() 
            => _stateSwitcher.SwitchState<LoadLevelState>();

        public void Exit()
        {

        }
    }
}
