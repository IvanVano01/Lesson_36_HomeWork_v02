using Assets.HomeWork.Develop.CommonUI;
using Assets.HomeWork.Develop.CommonUI.GamePlay;
using UnityEngine;

namespace Assets.HomeWork.Develop.GamePlay.UI
{
    public class GamePlayUIRoot : MonoBehaviour
    {
        [field: SerializeField] public ResultGameView ResultGameView { get; private set; }

        [field: SerializeField] public InputTextView InputSymbolView { get ; private set;}

        [field: SerializeField] public OnlyText OnlyText { get; private set; }

        [field: SerializeField] public Transform HUDLayer { get; private set; }

        [field: SerializeField] public Transform PopupsLayer { get; private set; } 

        [field: SerializeField] public Transform VFXLayer { get; private set; }
    }
}
