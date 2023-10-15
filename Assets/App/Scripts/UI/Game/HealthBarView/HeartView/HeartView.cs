using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.Game.HealthBarView.HeartView
{
    public class HeartView : MonoBehaviour
    {
        [SerializeField] private Vector3 showDirection;
        
        [SerializeField] [Min(0)] private float showTime;
        
        public void Show(float delay = 0)
        {
            transform.position -= showDirection;
            transform.DOMove(transform.position + showDirection, showTime)
                .SetEase(Ease.OutBounce)
                .SetDelay(delay);
        }

        public void Hide(bool destroyOnComplete = false)
        {
            transform.DOMove(transform.position - showDirection, showTime)
                .SetEase(Ease.OutExpo)
                .OnComplete(() =>
                {
                    if (destroyOnComplete) Destroy(gameObject);
                });
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }
    }
}