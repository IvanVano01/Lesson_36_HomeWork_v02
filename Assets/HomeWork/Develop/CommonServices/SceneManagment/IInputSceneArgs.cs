﻿using Assets.HomeWork.Develop.GamePlay;

namespace Assets.HomeWork.Develop.CommonServices.SceneManagment
{
    public interface IInputSceneArgs
    {
    }
     
    public class GameplayInputArgs : IInputSceneArgs//  для передачи аргумента в сцену GamePlay
    {
        public GameplayInputArgs(GameModeID gameMode)
        {
            GameMode = gameMode;
        }

        public GameModeID GameMode { get; } // аргумент для передачи в сцену GamePlay
    }

    public class MainMenuInputArgs : IInputSceneArgs//  для передачи аргумента в сцену MainMenu
    {
        // пока без аргументов
    }
}
