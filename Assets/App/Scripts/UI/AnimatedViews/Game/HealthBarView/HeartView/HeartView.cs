using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Game.HealthBarView.HeartView
{
    public class HeartView : MonoBehaviour
    {
        [SerializeField] private Vector3 showDirection;
        
        public void Show(float showTime, float delay = 0)
        {
            transform.position -= showDirection;
            transform.DOMove(transform.position + showDirection, showTime)
                .SetEase(Ease.OutBounce)
                .SetDelay(delay);
        }

        public void Hide(float showTime, float delay = 0, bool destroyOnComplete = false)
        {
            transform.DOMove(transform.position - showDirection, showTime)
                .SetEase(Ease.OutExpo)
                .SetDelay(delay)
                .OnComplete(() =>
                {
                    if (destroyOnComplete) Destroy(gameObject);
                });
        }

        private void OnDestroy()
        {
            transform.DOKill(true);
        }
    }
}