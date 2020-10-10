using System;
using UnityEngine;

namespace SunriseHirame.SimpleUI
{
    [RequireComponent (typeof (RectTransform), typeof (CanvasGroup))]
    public class UIView : MonoBehaviour
    {
        [SerializeField] private AnimationPreset inAnimation = default;
        [SerializeField] private AnimationPreset outAnimation = default;
        [SerializeField] private AnimationPreset loopAnimation = default;

        [SerializeField] private RectTransform rectTransform = default;
        [SerializeField] private CanvasGroup canvasGroup = default;
        
        private void OnEnable ()
        {
            Show ();
        }

        public void Show ()
        {
            if (inAnimation)
                inAnimation.AnimateIn (rectTransform, canvasGroup);
        }

        private void Reset ()
        {
            rectTransform = GetComponent<RectTransform> ();
            canvasGroup = GetComponent<CanvasGroup> ();
        }
    }
}