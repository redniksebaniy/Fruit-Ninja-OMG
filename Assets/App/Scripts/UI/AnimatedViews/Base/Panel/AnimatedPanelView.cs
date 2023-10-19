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
        
        [SerializeField] [Min(0)] private float showDelay;
        
        [SerializeField] [Min(0)] private float hideDelay;
        
        private Vector2 _openedPos;
        private Vector2 _closedPos;

        public override void Init()
        {
            _openedPos = _closedPos = panel.position;
            _closedPos -= openDirection.normalized * 2 * adapter.AdaptPixelPosition(parentCanvas.pixelRect.size);
        }

        public void ShowPanel()
        {
            panel.position = _closedPos;
            panel.DOMove(_openedPos, animationTime)
                .SetUpdate(true)
                .SetEase(Ease.OutBounce)
                .SetDelay(showDelay)
                .OnStart(() => panel.gameObject.SetActive(true));
        }

        public void HidePanel()
        {
            panel.position = _openedPos;
            panel.DOMove(_closedPos, animationTime)
                .SetUpdate(true)
                .SetEase(Ease.InFlash)
                .SetDelay(hideDelay)
                .OnComplete(() => panel.gameObject.SetActive(false));
        }
        
        private void OnDestroy()
        {
            panel.DOKill();
        }
    }
}
