using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Game.HealthBarView.HeartView
{
    public class HeartView : MonoBehaviour
    {
        public void Show(Vector2 endPosition, float showTime, float delay = 0)
        {
            transform.DOMoveX(endPosition.x, showTime).SetEase(Ease.OutSine).SetDelay(delay)
                .SetLink(gameObject);
            transform.DOMoveY(endPosition.y, showTime).SetEase(Ease.InBack).SetDelay(delay)
                .SetLink(gameObject);
        }

        public void Hide(float showTime, float delay = 0)
        {
            transform.DOScale(Vector3.zero, showTime)
                .SetEase(Ease.OutExpo)
                .SetLink(gameObject)
                .SetDelay(delay)
                .OnComplete(() =>
                {
                    Destroy(gameObject);
                });
        }
    }
}