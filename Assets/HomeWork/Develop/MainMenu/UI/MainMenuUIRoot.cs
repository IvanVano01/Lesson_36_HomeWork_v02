using Assets.HomeWork.Develop.CommonUI;
using Assets.HomeWork.Develop.CommonUI.GameModeSelect;
using UnityEngine;

namespace Assets.HomeWork.Develop.MainMenu.UI
{
    public class MainMenuUIRoot : MonoBehaviour
    {
        [field: SerializeField] public IconWithText CurrencyView { get; private set; }

        [field: SerializeField] public OnlyTextListView GameResultView { get; private set; }

        [field: SerializeField] public ButtonWithText ResetGameResultView { get; private set; }

        [field: SerializeField] public GameModeSelectorView GameModeSelectorView { get; private set; }

        [field: SerializeField] public Transform HUDLayer { get; private set; }

        [field: SerializeField] public Transform PopupsLayer { get; private set; } //слой с окнами(магазины и т.д)

        [field: SerializeField] public Transform VFXLayer { get; private set; }

    }
}
