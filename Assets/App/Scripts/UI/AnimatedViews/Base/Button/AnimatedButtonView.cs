using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace App.Scripts.UI.AnimatedViews.Base.Button
{
    public class AnimatedButtonView : MonoBehaviour
    {
        [SerializeField] private Image image;
        
        [SerializeField] [Min(0)] private float animationTime = 0.1f;

        [SerializeField] private Color pressedColor;
        
        [SerializeField] [Range(0, 1)] private float pressedScale = 0.9f;
        
        private Color _unpressedColor;

        public UnityEvent onClick = new();
        
        private void Start()
        {
            _unpressedColor = image.color;
        }

        public void Hold()
        {
            image.DOColor(pressedColor, animationTime).SetUpdate(true);
            transform.DOScale(Vector3.one * pressedScale, animationTime).SetUpdate(true);
        }

        public void Unhold()
        {
            image.DOColor(_unpressedColor, animationTime).SetUpdate(true);
            transform.DOScale(Vector3.one, animationTime).SetUpdate(true).SetEase(Ease.InOutBounce);
        }
        
        public void Press()
        {
            image.DOColor(_unpressedColor, animationTime);
            transform.DOScale(Vector3.one, animationTime).SetUpdate(true).SetEase(Ease.InOutBounce)
                .OnComplete(() => onClick?.Invoke());
        }

        private void OnDestroy()
        {
            image.DOKill();
            transform.DOKill();
        }
    }
}