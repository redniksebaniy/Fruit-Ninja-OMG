using System;
using App.Scripts.Architecture.MonoInitializable;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Base.CanvasGroup
{
    public class AnimatedCanvasGroupView : MonoInitializable
    {
        [SerializeField] private UnityEngine.CanvasGroup canvasGroup;
        
        [SerializeField] [Min(0)] private float animationTime = 0.25f;

        [SerializeField] private Ease showEase = Ease.OutSine;

        [SerializeField] private Ease hideEase = Ease.InSine;
        
        private float _currentAlpha;
        
        public override void Init()
        {
            _currentAlpha = canvasGroup.alpha;
            canvasGroup.blocksRaycasts = false;
        }

        public void ShowCanvasGroup(Action onComplete = null)
        {
            if (canvasGroup == null) return;
            
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 0;
            canvasGroup.DOFade(_currentAlpha, animationTime)
                .SetUpdate(true)
                .SetEase(showEase)
                .OnStart(() => canvasGroup.gameObject.SetActive(true))
                .OnComplete(() => onComplete?.Invoke());
        }

        public void HideCanvasGroup(Action onComplete = null)
        {
            if (canvasGroup == null) return;
            
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = _currentAlpha;
            canvasGroup.DOFade(0, animationTime)
                .SetUpdate(true)
                .SetEase(hideEase)
                .OnComplete(() =>
                {
                    canvasGroup.gameObject.SetActive(false);
                    canvasGroup.alpha = _currentAlpha;
                    onComplete?.Invoke();
                });
        }
        
        private void OnDestroy()
        {
            canvasGroup.DOKill();
        }
    }
}
