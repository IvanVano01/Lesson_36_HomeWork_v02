using Assets.HomeWork.Develop.GamePlay;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class InputSymbolPresenterFactory
    {
        public InputSymbolPresenter CreateInputSymbolPresenter(InputTextView view, Game game)
            => new InputSymbolPresenter(view, game);
    }
}
