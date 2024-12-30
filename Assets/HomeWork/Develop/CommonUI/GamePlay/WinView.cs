using UnityEngine;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class WinView : MonoBehaviour
    {
        [field: SerializeField] public ButtonWithText ButtonToMainMenu { get; private set; }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}
