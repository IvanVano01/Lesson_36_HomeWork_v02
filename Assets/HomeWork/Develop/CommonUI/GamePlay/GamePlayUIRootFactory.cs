using Assets.HomeWork.Develop.CommonServices.AssetManagment;
using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.GamePlay.UI;
using UnityEngine;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class GamePlayUIRootFactory
    {        
        private DIContainer _container;

        public GamePlayUIRootFactory(DIContainer container)
        {
            _container = container;            
        }

        public GamePlayUIRoot SpawnGamePlayUIRoot()
        {
            GamePlayUIRoot gamePlayUIRootPrefab = _container.Resolve<ResourcesAssetLoader>().LoadResource<GamePlayUIRoot>("GamePlay/UI/GamePlayUIRoot");

            GamePlayUIRoot gamePlayUIRootPrefab1 = GameObject.Instantiate(gamePlayUIRootPrefab);

            return gamePlayUIRootPrefab1;
        }
    }
}
