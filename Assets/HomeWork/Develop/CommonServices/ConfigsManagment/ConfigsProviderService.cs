using Assets.HomeWork.Develop.CommonServices.AssetManagment;
using Assets.HomeWork.Develop.Configs.Common.Game;
using Assets.HomeWork.Develop.Configs.Common.GameResult;
using Assets.HomeWork.Develop.Configs.Common.Wallet;

namespace Assets.HomeWork.Develop.CommonServices.ConfigsManagment
{
    public class ConfigsProviderService
    {
        private ResourcesAssetLoader _resourcesAssetLoader;

        public ConfigsProviderService(ResourcesAssetLoader resourcesAssetLoader)
        {
            _resourcesAssetLoader = resourcesAssetLoader;
        }

        public StartWalletConfig StartWalletConfig { get; private set; }
        public StartGameResultConfig StartGameResultConfig { get; private set; }
        public StartGameConfig StartGameConfig { get; private set; }
        public CurrencyIconsConfig CurrencyIconsConfig { get; private set; }
        public ResultTextsConfig ResultTextsConfig { get; private set; }

        public void LoadAll()
        {
            // здесь будем подгружать конфиги из папки ресурсов(Resources)
            LoadStartWalletConfig();
            LoadGameResultConfig();
            LoadStartGameConfig();
            LoadCurrencyIconsConfig();
            LoadResultTextsConfig();
        }

        private void LoadResultTextsConfig()
        {
            ResultTextsConfig = _resourcesAssetLoader.LoadResource<ResultTextsConfig>("Configs/Common/GameResult/ResultTextConfig");
        }

        private void LoadGameResultConfig()
        {
            StartGameResultConfig = _resourcesAssetLoader.LoadResource<StartGameResultConfig>("Configs/Common/GameResult/GameResultConfig");
        }

        private void LoadStartWalletConfig()
        {
            StartWalletConfig = _resourcesAssetLoader.LoadResource<StartWalletConfig>("Configs/Common/Wallet/StartWalletConfig");
        }

        private void LoadStartGameConfig()
        {
            StartGameConfig = _resourcesAssetLoader.LoadResource<StartGameConfig>("Configs/Common/Game/StartGameConfig");
        }

        private void LoadCurrencyIconsConfig()
        {
            CurrencyIconsConfig = _resourcesAssetLoader.LoadResource<CurrencyIconsConfig>("Configs/Common/Wallet/CurrencyIconsConfig");
        }        
    }
}
