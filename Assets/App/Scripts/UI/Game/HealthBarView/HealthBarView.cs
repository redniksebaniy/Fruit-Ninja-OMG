using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.UI.Game.HealthBarView
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private HeartView.HeartView prefab;
        
        [SerializeField] private Vector3 offset;
        
        private readonly Stack<HeartView.HeartView> _hearts = new();

        public void SetHearts(int heartCount)
        {
            for (int i = 0; i < heartCount; i++)
            {
                AddHeart(i);
            }
        }

        public void RemoveHeart()
        {
            if (_hearts.Count > 0)
            {
                var heart = _hearts.Pop();
                heart.Hide(true);
            }
        }

        public void AddHeart(float delay = 0)
        {
            var heart = Instantiate(prefab, transform);
            heart.transform.position = transform.position + offset * _hearts.Count;
            heart.Show(delay);
            _hearts.Push(heart);
        }
    }
}