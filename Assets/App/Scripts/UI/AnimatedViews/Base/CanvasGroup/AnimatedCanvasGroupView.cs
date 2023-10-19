using App.Scripts.Architecture.MonoInitializable;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Base.CanvasGroup
{
    public class AnimatedCanvasGroupView : MonoInitializable
    {
        [SerializeField] private UnityEngine.CanvasGroup canvasGroup;
        
        [SerializeField] [Min(0)] private float animationTime = 0.25f;

        private float _currentAlpha;
        
        public override void Init()
        {
            _currentAlpha = canvasGroup.alpha;
            canvasGroup.blocksRaycasts = false;
        }

        public void ShowCanvasGroup()
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 0;
            canvasGroup.DOFade(_currentAlpha, animationTime)
                .SetUpdate(true)
                .SetEase(Ease.OutFlash)
                .OnStart(() => canvasGroup.gameObject.SetActive(true));
        }

        public void HideCanvasGroup()
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = _currentAlpha;
            canvasGroup.DOFade(0, animationTime)
                .SetUpdate(true)
                .SetEase(Ease.OutFlash)
                .OnComplete(() =>
                {
                    canvasGroup.gameObject.SetActive(false);
                    canvasGroup.alpha = _currentAlpha;
                });
        }
        
        private void OnDestroy()
        {
            canvasGroup.DOKill();
        }
    }
}
