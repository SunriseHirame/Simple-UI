using UnityEngine;

namespace SunriseHirame.SimpleUI
{
    public class UIViewGroup : MonoBehaviour
    {
        [SerializeField] private UIView[] controlledViews = default;
        
        private void Awake ()
        {
            foreach (var view in controlledViews)
            {
                view.ShowStarted += OnShowStarted;
            }
            
            controlledViews[0].Show ();
        }

        private void OnShowStarted (UIView shownView)
        {
            foreach (var view in controlledViews)
            {
                if (shownView != view)
                    view.Hide ();
            }
        }
    }

}