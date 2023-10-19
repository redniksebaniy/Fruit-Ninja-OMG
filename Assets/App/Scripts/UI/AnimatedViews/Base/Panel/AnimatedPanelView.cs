using App.Scripts.Utilities.CameraAdapter;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Base.Panel
{
    public class AnimatedPanelView : MonoBehaviour
    {
        [SerializeField] private Transform panel;
        
        [SerializeField] private Canvas parentCanvas;
        
        [SerializeField] private OrthographicCameraAdapter adapter;
        
        [SerializeField] private Vector2 openDirection;

        [SerializeField] [Min(0)] private float animationTime = 0.25f;
        
        private Vector2 _openedPos;
        private Vector2 _closedPos;

        private void Start()
        {
            _openedPos = _closedPos = panel.position;
            _closedPos -= openDirection.normalized * adapter.AdaptPixelPosition(parentCanvas.pixelRect.size);
        }

        public void ShowPanel()
        {
            panel.gameObject.SetActive(true);
            panel.position = _closedPos;
            panel.DOMove(_openedPos, animationTime).SetUpdate(true).SetEase(Ease.OutBounce);
        }

        public void HidePanel()
        {
            panel.position = _openedPos;
            panel.DOMove(_closedPos, animationTime).SetUpdate(true).SetEase(Ease.InFlash);
        }
        
        private void OnDestroy()
        {
            panel.DOKill();
        }
    }
}
