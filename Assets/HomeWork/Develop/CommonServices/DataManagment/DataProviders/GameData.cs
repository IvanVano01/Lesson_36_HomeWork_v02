using System;
using System.Collections.Generic;

namespace Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders
{
    [Serializable]
    public class GameData : ISaveData
    {
        public List<int> Numbers = new();
        public List<char> Letters = new List<char>();
    }
}
