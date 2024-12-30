using UnityEngine;

namespace Assets.HomeWork.Develop.CommonUI.GamePlay
{
    public class ResultGameView : MonoBehaviour
    {
        [field: SerializeField] public WinView WinView { get; private set; }
        [field: SerializeField] public DefeatView DefeatView { get; private set; }

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}
