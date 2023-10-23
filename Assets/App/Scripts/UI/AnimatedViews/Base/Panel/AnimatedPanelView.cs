using System;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Utilities.CameraAdapter;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Base.Panel
{
    public class AnimatedPanelView : MonoInitializable
    {
        [SerializeField] private Transform panel;
        
        [SerializeField] private Canvas parentCanvas;
        
        [SerializeField] private OrthographicCameraAdapter adapter;
        
        [SerializeField] private Vector2 openDirection;

        [SerializeField] [Min(0)] private float animationTime = 0.25f;

        [SerializeField] private Ease showEase = Ease.OutSine;

        [SerializeField] private Ease hideEase = Ease.InSine;
        
        private Vector2 _openedPos;
        private Vector2 _closedPos;

        public override void Init()
        {
            _openedPos = _closedPos = panel.position;
            _closedPos -= openDirection.normalized * 2 * adapter.AdaptPixelPosition(parentCanvas.pixelRect.size);
        }

        public void ShowPanel(Action onComplete = null)
        {
            if (panel == null) return;
            
            panel.position = _closedPos;
            panel.DOMove(_openedPos, animationTime)
                .SetUpdate(true)
                .SetEase(showEase)
                .OnStart(() =>
                {
                    panel.gameObject.SetActive(true);
                })
                .OnComplete(() =>
                {
                    onComplete?.Invoke();
                });
        }

        public void HidePanel(Action onComplete = null)
        {
            if (panel == null) return;
            
            panel.position = _openedPos;
            panel.DOMove(_closedPos, animationTime)
                .SetUpdate(true)
                .SetEase(hideEase)
                .OnStart(() =>
                {
                    panel.gameObject.SetActive(true);
                })
                .OnComplete(() =>
                {
                    panel.gameObject.SetActive(false);
                    onComplete?.Invoke();
                });
        }
        
        private void OnDestroy()
        {
            panel.DOKill();
        }
    }
}
