using UnityEngine;

namespace Assets.CodeBase.Core
{
    internal class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _heroPrefab;

        private readonly Extensions _services = Extensions.Instance;

        private void Start()
        {
            InitializeServices();

            GameStateMachine game = new GameStateMachine();
            game.SwitchState<BootstrapperState>();
        }

        private void InitializeServices()
        {
            _services.RegisterService(new FactoryHero(_heroPrefab));
            _services.RegisterService(new InputService());
        }
    }
}
