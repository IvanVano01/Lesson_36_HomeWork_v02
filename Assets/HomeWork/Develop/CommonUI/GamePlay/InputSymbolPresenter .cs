using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.GamePlay;
using System;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class InputSymbolPresenter : IInitializable, IDisposable
    {        
        private Game _game;

        private InputTextView _view;

        public InputSymbolPresenter(InputTextView view, Game game)
        {   
            _game = game;
            _view = view;
        }      

        public void Inintialize()
        {
            _view.InputedSymbols += OnInputedSymbols;
        }

        public void Dispose()
        {
            _view.InputedSymbols -= OnInputedSymbols;
        }

        private void OnInputedSymbols(string symbols)
        {           
            _game.ToCheckInputSymbol(symbols);
        }
    }
}
