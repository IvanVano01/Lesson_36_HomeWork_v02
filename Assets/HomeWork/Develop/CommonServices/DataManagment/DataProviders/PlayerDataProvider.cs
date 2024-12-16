using Assets.HomeWork.Develop.CommonServices.Wallet;
using System;
using System.Collections.Generic;

namespace Assets.HomeWork.Develop.CommonServices.DataManagment.DataProviders
{
    public class PlayerDataProvider : DataProvider<PlayerData>// конкретный провайдер для класса игрока
    {
        // тут будем передавать сервис конфигов

        public PlayerDataProvider(ISaveLoadService saveLoadService) : base(saveLoadService)
        {

        }

        protected override PlayerData GetOriginData()
        {
            return new PlayerData()
            {
               WalletData = InitWalletData() // создаём данные для игрока(кошелёк с валютами)
            };
        }

        private Dictionary<CurrencyTypes, int> InitWalletData()
        {
            Dictionary<CurrencyTypes, int> walletData = new();

            foreach(CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes))) // заполняем словарь валютами из энама"CurrencyType"
            {
                walletData.Add(currencyType, 0);// по умолчанию кол-во каждой валюты =0
            }

            return walletData;
        }
    }
}
