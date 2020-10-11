using System;
using UnityEngine;

namespace SunriseHirame.SimpleUI
{
    public delegate void UIStateAction (UIView view);

    public enum UIState
    {
        Visible,
        Showing,
        Hidden,
        Hiding,
        //Disabled
    }
    
    [RequireComponent (typeof (RectTransform), typeof (CanvasGroup))]
    public class UIView : MonoBehaviour
    {
        public event UIStateAction ShowStarted;
        public event UIStateAction HideStarted;
        
        [SerializeField] private AnimationPreset inAnimation = default;
        [SerializeField] private AnimationPreset outAnimation = default;
        [SerializeField] private AnimationPreset loopAnimation = default;

        [SerializeField] private RectTransform rectTransform = default;
        [SerializeField] private CanvasGroup canvasGroup = default;

        private UIState state;
        
        public void Show ()
        {
            // if (state == UIState.Visible || state == UIState.Showing)
            //     return;
            
            if (gameObject.activeSelf == false)
                gameObject.SetActive (true);
            
            Debug.Log ("SHOW");
            ShowStarted?.Invoke (this);
            
            if (inAnimation)
                inAnimation.AnimateIn (rectTransform, canvasGroup);
        }

        public void Hide ()
        {
            // if (state == UIState.Hidden || state == UIState.Hiding)
            //     return;
            HideStarted?.Invoke (this);
            
            gameObject.SetActive (false);
        }
        
        private void Reset ()
        {
            rectTransform = GetComponent<RectTransform> ();
            canvasGroup = GetComponent<CanvasGroup> ();
        }
    }
}