using UnityEngine;

namespace Assets.CodeBase.Core
{
    internal class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject _heroPrefab;
        [SerializeField] private GameObject _projectilePrefab;

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
            _services.RegisterService(new FactoryProjectile(_projectilePrefab));
            _services.RegisterService(new InputService());
            _services.RegisterService(new SaveLoadService());
        }
    }
}
