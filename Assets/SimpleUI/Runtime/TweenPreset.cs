using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SunriseHirame.SimpleUI
{
    [CreateAssetMenu (menuName = "Simple UI/Tween Preset")]
    public class TweenPreset : ScriptableObject
    {
        [Header ("Position")]
        [SerializeField] private TweenDefinition positionTween = default;
        
        [Header ("Rotation")]
        [SerializeField] private TweenDefinition rotationTween = default;
        
        [Header ("Scale")]
        [SerializeField] private TweenDefinition scaleTween = default;
        
        [Header ("Color")]
        [SerializeField] private TweenDefinition colorTween = default;
        
        public async UniTask AnimateIn (RectTransform target, CanvasGroup canvasGroup)
        {
            var sequence = DOTween.Sequence ();
            
            var targetScale = target.localScale;
            target.localScale = Vector3.zero;
            var scale = target.DOScale (targetScale, scaleTween.Duration);
            scale.SetEase (scaleTween.EaseMode);
            sequence.Join (scale);

            if (canvasGroup)
            {
                var targetColor = canvasGroup.alpha;
                canvasGroup.alpha = 0;
                var color = canvasGroup.DOFade (targetColor, colorTween.Duration);
                color.SetEase (colorTween.EaseMode);
                sequence.Join (color);   
            }

            await sequence.AsyncWaitForCompletion ();
        }
        
        [System.Serializable]
        private struct TweenDefinition
        {
            public bool Enabled;
            public float Duration;
            public Ease EaseMode;
            
            public static TweenDefinition Default => new TweenDefinition
            {
                Enabled = false,
                Duration = 0.7f,
                EaseMode = Ease.InOutSine
            };
        }
        
    }
}
