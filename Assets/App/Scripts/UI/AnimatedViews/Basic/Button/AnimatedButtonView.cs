using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scripts.UI.AnimatedViews.Basic.Button
{
    public class AnimatedButtonView : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
    {
        [SerializeField] private UnityEngine.UI.Button button;

        [SerializeField] [Min(0)] private float animationTime = 0.1f;

        [SerializeField] private Color pressedColor;
        
        [SerializeField] [Range(0, 1)] private float pressedScale = 0.9f;

        private Color _unpressedColor;

        public void Start()
        {
            _unpressedColor = button.image.color;
        }

        private void Press()
        {
            if (!button.interactable) return;
            
            button.image.DOColor(pressedColor, animationTime).SetUpdate(true);
            transform.DOScale(Vector3.one * pressedScale, animationTime).SetUpdate(true);
        }

        private void UnPress()
        {
            if (!button.interactable) return;
            
            button.image.DOColor(_unpressedColor, animationTime).SetUpdate(true);
            transform.DOScale(Vector3.one, animationTime).SetUpdate(true).SetEase(Ease.OutBounce);
        }

        public void OnPointerDown(PointerEventData eventData) => Press();

        public void OnPointerExit(PointerEventData eventData) => UnPress();

        public void OnPointerUp(PointerEventData eventData) => UnPress();
        
        public void OnDestroy()
        {
            button.image.DOKill();
            transform.DOKill();
        }
    }
}