using UnityEngine;

namespace SunriseHirame.SimpleUI
{
    [CreateAssetMenu (menuName = "Simple UI/Pop Up Reference")]
    public class UIPopUpReference : ScriptableObject
    {
        [SerializeField] private UIPopUp popUpProto = default;

        public UIPopUp ShowPopUp ()
        {
            return Instantiate (popUpProto);
        }
    }
}
