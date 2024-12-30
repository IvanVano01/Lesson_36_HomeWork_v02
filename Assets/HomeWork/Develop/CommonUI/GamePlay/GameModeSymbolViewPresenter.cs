using Assets.HomeWork.Develop.GamePlay;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class GameModeSymbolViewPresenter 
    {
        private readonly string _description = " Введите символы на экране! ";       
        private Game _game;

        private OnlyText _view;

        public GameModeSymbolViewPresenter(Game game, OnlyText view)
        {
            _game = game;
            _view = view;
        }

        public void Enable()
        {
            _view.SetTextValue(_game.GetSympolList());                      
            _view.SetTextName(_description);
        }

        public void Disable()
        {

        }       
    }
}
