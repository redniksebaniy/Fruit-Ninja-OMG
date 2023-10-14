using UnityEngine;
using DG.Tweening;

namespace App.Scripts.UI.Game.View
{
    public class HeartView : MonoBehaviour
    {
        [SerializeField] private Vector3 offset;
        
        [SerializeField] [Min(0)] private float showTime;
        public void Show(float delay)
        {
            transform.position += offset;
            transform.DOMove(transform.position - offset, showTime).SetEase(Ease.OutBack).SetDelay(delay);
        }
    }
}