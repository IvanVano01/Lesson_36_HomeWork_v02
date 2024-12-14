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

        public void ToSelectGameModeView()
        {
            Debug.Log(" Выберите режим игры!");
            Debug.Log("Для режима цифр, Нажмите клавишу 1 ");
            Debug.Log("Для режима букв, Нажмите клавишу 2 ");
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _sceneSwitcher.ProcessSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(GameModeID.EnterNumbers)));

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _sceneSwitcher.ProcessSwitchSceneFor(new OutputMainMenuArgs(new GameplayInputArgs(GameModeID.EnterLetters)));            
        }
    }
}
