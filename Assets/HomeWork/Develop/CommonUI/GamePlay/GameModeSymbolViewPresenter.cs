using Assets.HomeWork.Develop.CommonServices.GameService;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class GameModeSymbolViewPresenter 
    {
        private readonly string _description = " Введите символы на экране! ";       
        
        private GeneratorRandomSymbolsService _generatorRandomSymbolsService;

        private OnlyText _view;

        public GameModeSymbolViewPresenter(GeneratorRandomSymbolsService generatorRandomSymbolsService, OnlyText view)
        {           
            _generatorRandomSymbolsService = generatorRandomSymbolsService;
            _view = view;
        }

        public void Enable()
        {
            _view.SetTextValue(_generatorRandomSymbolsService.GetSympolList());                      
            _view.SetTextName(_description);
        }

        public void Disable()
        {

        }       
    }
}
