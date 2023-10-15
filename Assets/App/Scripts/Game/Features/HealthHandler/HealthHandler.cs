using System;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Spawning.LevelHandler;
using App.Scripts.UI.Game.HealthBarView;
using UnityEngine;
using UnityEngine.Events;

namespace App.Scripts.Game.Features.HealthHandler
{
    public class HealthHandler : MonoInitializable
    {
        [SerializeField] private HealthBarView healthBarView;
        
        [SerializeField] [Min(1)] private int heartCount;

        [SerializeField] private UnityEvent OnZeroHealth;
        
        public override void Init()
        {
            healthBarView.SetHearts(heartCount);
        }
        
        public void RemoveHeart()
        {
            healthBarView.RemoveHeart();
            if (--heartCount == 0)
            {
                OnZeroHealth?.Invoke();
            }
        }
        
        public void AddHeart()
        {
            healthBarView.AddHeart();
            heartCount++;
        }
    }
}