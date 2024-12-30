using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.HomeWork.Develop.CommonUI.GameModeSelect
{
    public class GameModeSelectorView : MonoBehaviour
    {
        public event Action PressedButtonNumber;
        public event Action PressedButtonLetters;

        [SerializeField] private Button _modeNumbers;

        [SerializeField] private Button _modeLetters;

        [SerializeField] private TMP_Text _modeDescription;

        private void OnEnable()
        {
            _modeNumbers.onClick.AddListener(OnClickNumbers);
            _modeLetters.onClick.AddListener(OnClickLetters);
        }

        private void OnClickNumbers()
        {
            PressedButtonNumber?.Invoke();            
        }

        private void OnClickLetters()
        {
            PressedButtonLetters?.Invoke();            
        }

        private void OnDisable()
        {
            _modeNumbers.onClick.RemoveListener(OnClickNumbers);
            _modeLetters.onClick.RemoveListener(OnClickLetters);
        }

        public void SetDescription(string description) => _modeDescription.text = description;
    }
}
