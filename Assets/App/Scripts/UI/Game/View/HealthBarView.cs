
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.UI.Game.View
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private HeartView health;
        
        [SerializeField] private Vector3 offset;
        
        private Stack<HeartView> hearts = new();

        private int _healthCount;
        
        public void Start()
        {
            for (int i = 0; i < _healthCount; i++)
            {
                AddHealth(i);
            }
        }
        
        public void RemoveHealth()
        {
            Destroy(hearts.Pop());
            _healthCount--;
        }

        public void AddHealth(float delay = 0)
        {
            var newHealth = Instantiate(health, transform);
            newHealth.transform.position += offset * ++_healthCount;
            newHealth.Show(delay);
            hearts.Push(newHealth);
        }
    }
}