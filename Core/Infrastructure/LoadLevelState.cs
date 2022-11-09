using UnityEngine;

namespace Assets.CodeBase.Core
{
    internal class LoadLevelState : IState
    {
        private readonly FactoryHero _factoryHero;
        private readonly SaveLoadService _saveLoadService;

        public LoadLevelState(FactoryHero factoryHero, SaveLoadService saveLoadService)
        { 
            _factoryHero = factoryHero;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            Load();
            CreateHero();
        }

        private void Load()
        {
            _saveLoadService.Load();
        }

        private void CreateHero()
        {
            GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
            Vector3 initialHeroSpawnPoint = spawnPoint.transform.position;
            _factoryHero.BuildHero(initialHeroSpawnPoint);
        }

        public void Exit()
        {

        }
    }
}
