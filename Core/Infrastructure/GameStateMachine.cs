using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.CodeBase.Core
{
    public class GameStateMachine: IStateSwitcher
    {
        private readonly List<IState> _states;
        private IState _currentState;
        private Extensions _services = Extensions.Instance;

        public GameStateMachine()
        {
            _states = new List<IState>
            {
                new BootstrapperState(this),
                new LoadLevelState(_services.GetService<FactoryHero>())
            };
        }

        public void SwitchState<TState>() 
            where TState: IState
        {
            CheckExistenceOfStateAndThrowException<TState>(out IState newState);
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        private void CheckExistenceOfStateAndThrowException<TState>(out IState newState) where TState : IState
        {
            newState = _states.FirstOrDefault(state => state is TState);
            if (newState == null)
            {
                throw new EntryPointNotFoundException("State not found!");
            }
        }
    }
}


