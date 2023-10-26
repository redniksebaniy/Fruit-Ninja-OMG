using System;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Base;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Fade
{
    public class AnimatedCanvasFadeView : CanvasGroupView
    {
        [Header("Animation Options")]
        [SerializeField] [Min(0)] private float animationTime = 0.25f;

        [SerializeField] private Ease showEase = Ease.OutSine;

        [SerializeField] private Ease hideEase = Ease.InSine;
        
        private float _currentAlpha;
        
        public override void Init()
        {
            _currentAlpha = canvasGroup.alpha;
            canvasGroup.interactable = false;
        }

        public override void Show(Action onComplete = null)
        {
            if (canvasGroup == null) return;

            canvasGroup.interactable = false;
            canvasGroup.alpha = 0;
            canvasGroup.DOFade(_currentAlpha, animationTime)
                .SetUpdate(true)
                .SetEase(showEase)
                .OnStart(() => canvasGroup.gameObject.SetActive(true))
                .OnComplete(() =>
                {
                    canvasGroup.interactable = true;
                    onComplete?.Invoke();
                });
        }

        public override void Hide(Action onComplete = null)
        {
            if (canvasGroup == null) return;
            
            canvasGroup.interactable = false;
            canvasGroup.alpha = _currentAlpha;
            canvasGroup.DOFade(0, animationTime)
                .SetUpdate(true)
                .SetEase(hideEase)
                .OnComplete(() =>
                {
                    canvasGroup.gameObject.SetActive(false);
                    canvasGroup.alpha = _currentAlpha;
                    
                    canvasGroup.interactable = true;
                    onComplete?.Invoke();
                });
        }
        
        private void OnDestroy()
        {
            canvasGroup.DOKill();
        }
    }
}
