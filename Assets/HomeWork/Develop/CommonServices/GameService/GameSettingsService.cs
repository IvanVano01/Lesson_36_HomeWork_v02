using Assets.HomeWork.Develop.CommonServices.ConfigsManagment;
using Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders;
using System.Collections.Generic;

namespace Assets.HomeWork.Develop.CommonServices.GameService
{
    public class GameSettingsService 
    {
        private ConfigsProviderService _configProviderService;
        
        private List<int> _numbers = new();
        private List<char> _letters = new();
        private int _maxAmountCharLength;

        public IReadOnlyList<int> GetNumbers() => _numbers;  
        public IReadOnlyList<char> GetLetters() => _letters;
        public int MaxAmountCharLength => _maxAmountCharLength;

        public GameSettingsService(ConfigsProviderService configProviderService)
        {            
            _configProviderService = configProviderService;

            _numbers = new List<int>(_configProviderService.StartGameConfig.GetNumbers);
            _letters = new List<char>(_configProviderService.StartGameConfig.GetLetters);
            _maxAmountCharLength = _configProviderService.StartGameConfig.MaxAmountCharLength;
        }       
    }
}
