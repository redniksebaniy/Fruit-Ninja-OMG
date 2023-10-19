using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.UI.AnimatedViews.Game.HealthBarView
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private HeartView.HeartView prefab;
        
        [SerializeField] private Vector3 offset;
        
        private readonly Stack<HeartView.HeartView> _hearts = new();

        private float _timeForSpawn;
        
        public void SetHearts(int heartCount, float time)
        {
            _timeForSpawn = time / heartCount;
            for (int i = 0; i < heartCount; i++)
            {
                AddHeart(_timeForSpawn, i * _timeForSpawn);
            }
        }

        public void RemoveHeart()
        {
            if (_hearts.Count == 0) return;
            
            var heart = _hearts.Pop();
            if (heart != null)
            {
                heart.Hide(_timeForSpawn, 0, true);
            }
        }

        public void AddHeart(float showTime, float delay = 0)
        {
            var heart = Instantiate(prefab, transform);
            heart.transform.position = transform.position + offset * _hearts.Count;
            heart.Show(showTime, delay);
            _hearts.Push(heart);
        }
    }
}