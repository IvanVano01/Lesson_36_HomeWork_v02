using System;

namespace Assets.HomeWork.Develop.GamePlay
{
    public interface IGame
    {
        event Action Won;
        event Action Lost;

        void Update();
    }
}
