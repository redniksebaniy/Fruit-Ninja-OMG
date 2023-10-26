using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scripts.UI.AnimatedViews.Basic.Button
{
    public class AnimatedButtonView : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerClickHandler
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
            button.image.DOColor(pressedColor, animationTime).SetUpdate(true);
            transform.DOScale(Vector3.one * pressedScale, animationTime).SetUpdate(true);
        }

        private void UnPress()
        {
            button.image.DOColor(_unpressedColor, animationTime).SetUpdate(true);
            transform.DOScale(Vector3.one, animationTime).SetUpdate(true).SetEase(Ease.OutBounce);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (button.interactable && !DOTween.IsTweening(transform)) Press();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            UnPress();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UnPress();
        }

        private void OnDisable() => UnPress();

        private void OnDestroy()
        {
            button.image.DOKill();
            transform.DOKill();
        }
    }
}