using Assets.HomeWork.Develop.CommonServices.SceneManagment;
using UnityEngine;

namespace Assets.HomeWork.Develop.GamePlay.Infrastructure
{
    public class GameModeSelector
    {
        private SceneSwitcher _sceneSwitcher;

        public GameModeSelector(SceneSwitcher sceneSwitcher)
        {
            _sceneSwitcher = sceneSwitcher;
        }

        public string ToSetSelectGameModeDescription()
        {
            string description = "Выберите режим игры и нажмите на кнопку ! ";
            return description;            
        }        

        public void SetModeNumbers() => _sceneSwitcher.ProcessSwitchSceneFor
            (new OutputMainMenuArgs(new GameplayInputArgs(GameModeID.EnterNumbers)));
        public void SetModeLetters() => _sceneSwitcher.ProcessSwitchSceneFor
            (new OutputMainMenuArgs(new GameplayInputArgs(GameModeID.EnterLetters)));
    }
}
