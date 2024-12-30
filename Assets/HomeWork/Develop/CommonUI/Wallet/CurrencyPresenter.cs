using Assets.HomeWork.Develop.CommonServices.DI;
using Assets.HomeWork.Develop.CommonServices.Wallet;
using Assets.HomeWork.Develop.Configs.Common.Wallet;
using Assets.HomeWork.Develop.Utils.Reactive;
using System;

namespace Assets.HomeWork.Develop.CommonUI.Wallet
{
    public class CurrencyPresenter : IInitializable, IDisposable// презеттер для связки view и model
    {
        //бизнес логика
        private IReadOnlyVariable<int> _currency;// ссылка на модель
        private CurrencyTypes _currencyType;

        //визуал
        private IconWithText _currencyView;// (вьюха)
        private CurrencyIconsConfig _currencyIconsConfig;

        public CurrencyPresenter(IReadOnlyVariable<int> currency, 
            CurrencyTypes currencyType, 
            IconWithText currencyView, 
            CurrencyIconsConfig currencyIconsConfig)
        {
            _currency = currency;
            _currencyType = currencyType;
            _currencyView = currencyView;
            _currencyIconsConfig = currencyIconsConfig;
        }

        public void Inintialize()
        {
            UpdateValue(_currency.Value);
            _currencyView.SetIcon(_currencyIconsConfig.GetSpriteFor(_currencyType));            

            _currency.Changed += OnCurrencyChanged;
        }

        public void Dispose()
        {
            _currency.Changed -= OnCurrencyChanged;
        }

        private void OnCurrencyChanged(int arg1, int newValue) => UpdateValue(newValue);        

        private void UpdateValue(int value) => _currencyView.SetText(value.ToString());
       
    }
}
