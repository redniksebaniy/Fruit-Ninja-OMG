using App.Scripts.UI.AnimatedViews.Base.Int;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Game.Score
{
    public class ScoreLabelView : AnimatedIntView
    {
        [SerializeField] [Min(0)] private float appearTime;
        
        [SerializeField] private Vector3 moveDirection;
        
        [SerializeField] [Min(0)] private float moveTime;

        [SerializeField] [Min(0)] private float disappearTime;
        
        private void OnEnable()
        {
            transform.localScale = Vector3.zero;
            Play();
        }

        private void Play()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(transform.DOScale(Vector3.one, appearTime).SetEase(Ease.OutBack));
            sequence.Insert(0, transform.DOMove(transform.position + moveDirection, moveTime));
            sequence.Append(transform.DOScale(Vector3.zero, disappearTime).SetEase(Ease.InBack)
                .OnComplete(() => Destroy(gameObject)));

            sequence.Play();
        }
    }
}