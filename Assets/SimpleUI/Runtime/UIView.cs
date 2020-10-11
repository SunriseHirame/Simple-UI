using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace SunriseHirame.SimpleUI
{
    public delegate void UIStateAction (UIView view);

    public enum UIState
    {
        UnInitialized,
        Active,
        Showing,
        Hidden,
        Hiding,
        Disabled
    }
    
    [RequireComponent (typeof (RectTransform), typeof (CanvasGroup))]
    public class UIView : MonoBehaviour
    {
        public event UIStateAction ShowStarted;
        public event UIStateAction HideStarted;
        
        [SerializeField] private TweenPreset inAnimation = default;
        [SerializeField] private TweenPreset outAnimation = default; 
        [SerializeField] private TweenPreset loopAnimation = default;

        [SerializeField] private RectTransform rectTransform = default;
        [SerializeField] private CanvasGroup canvasGroup = default;

        private UIState state = UIState.UnInitialized;

        public bool IsVisible => state == UIState.Showing || state == UIState.Active || state == UIState.Hiding;
        
        public void Show ()
        {
            if (state == UIState.Active || state == UIState.Showing)
                return;

            state = UIState.Showing;
            
            if (gameObject.activeSelf == false)
                gameObject.SetActive (true);
            
            Debug.Log ("SHOW");
            ShowStarted?.Invoke (this);
            
            if (inAnimation)
                inAnimation.AnimateIn (rectTransform, canvasGroup);

            state = UIState.Active;
        }

        public void Hide ()
        {
            if (state == UIState.Hidden || state == UIState.Hiding)
                return;

            state = UIState.Hiding;
            
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