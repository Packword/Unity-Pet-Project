using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.CodeBase.Core
{
    public class GameStateMachine: IStateSwitcher
    {
        private readonly List<IState> _states;
        private readonly Extensions _services = Extensions.Instance;
        private IState _currentState;

        public GameStateMachine() =>
            _states = new List<IState>
            {
                new BootstrapperState(this),
                new LoadLevelState(_services.GetService<FactoryHero>())
            };

        public void SwitchState<TState>() 
            where TState: IState
        {
            if (TryGetNextState<TState>(out IState newState))
                EnterNextState(newState);
            else
                throw new EntryPointNotFoundException("State not found!");
        }

        private void EnterNextState(IState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        private bool TryGetNextState<TState>(out IState newState) where TState : IState
        {
            newState = _states.FirstOrDefault(state => state is TState);

            if (newState != null)
                return true;
         
            return false;
        }
    }
}
