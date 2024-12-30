using System;
using UnityEngine;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{    
    public class DefeatView : MonoBehaviour
    {
        [field: SerializeField] public ButtonWithText ButtonReturnGame { get; private set; }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}
