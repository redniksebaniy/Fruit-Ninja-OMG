using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Game.HealthBarView.HeartView
{
    public class HeartView : MonoBehaviour
    {
        public void Show(Vector2 endPosition, float showTime, float delay = 0)
        {
            transform.DOMoveX(endPosition.x, showTime).SetEase(Ease.OutSine).SetDelay(delay);
            transform.DOMoveY(endPosition.y, showTime).SetEase(Ease.InOutBack).SetDelay(delay);
        }

        public void Hide(float showTime, float delay = 0)
        {
            transform.DOScale(Vector3.zero, showTime)
                .SetEase(Ease.OutExpo)
                .SetDelay(delay)
                .OnComplete(() =>
                {
                    Destroy(gameObject);
                });
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}