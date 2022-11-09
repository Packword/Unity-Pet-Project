using UnityEngine;

namespace Assets.CodeBase.Core
{
    internal class LoadLevelState : IState
    {
        private readonly FactoryHero _factoryHero;

        public LoadLevelState(FactoryHero factoryHero)
        { 
            _factoryHero = factoryHero;
        }

        public void Enter()
        {
            CreateHero();
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
