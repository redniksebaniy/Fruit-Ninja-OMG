using System;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Base;
using App.Scripts.Utilities.CameraAdapter;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Move
{
    public class AnimatedCanvasMoveView : CanvasGroupView
    {
        [SerializeField] private Canvas parentCanvas;
        
        [SerializeField] private OrthographicCameraAdapter adapter;
        
        [Header("Animation Options")]
        [SerializeField] private Vector2 showDirection;

        [SerializeField] [Min(0)] private float animationTime = 0.25f;

        [SerializeField] private Ease showEase = Ease.OutSine;

        [SerializeField] private Ease hideEase = Ease.InSine;

        private Transform _canvasTransform;
        
        private Vector2 _openedPos;
        private Vector2 _closedPos;

        public override void Init()
        {
            _canvasTransform = canvasGroup.transform;
            _openedPos = _closedPos = _canvasTransform.position;
            _closedPos -= showDirection.normalized * 2 * adapter.AdaptPixelPosition(parentCanvas.pixelRect.size);
            canvasGroup.interactable = false;
        }

        public override void Show(Action onComplete = null)
        {
            if (canvasGroup == null) return;
            
            canvasGroup.interactable = false;
            _canvasTransform.position = _closedPos;
            _canvasTransform.DOMove(_openedPos, animationTime)
                .SetUpdate(true)
                .SetLink(gameObject)
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
            _canvasTransform.position = _openedPos;
            _canvasTransform.DOMove(_closedPos, animationTime)
                .SetUpdate(true)
                .SetLink(gameObject)
                .SetEase(hideEase)
                .OnStart(() => canvasGroup.gameObject.SetActive(true))
                .OnComplete(() =>
                {
                    canvasGroup.gameObject.SetActive(false);
                    onComplete?.Invoke();
                });
        } 
    }
}
