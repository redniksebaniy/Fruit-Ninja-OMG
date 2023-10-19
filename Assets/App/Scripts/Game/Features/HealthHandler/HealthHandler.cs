using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Spawning.LevelHandler.Scriptable;
using App.Scripts.UI.AnimatedViews.Game.HealthBarView;
using App.Scripts.UI.Installers.Game;
using UnityEngine;

namespace App.Scripts.Game.Features.HealthHandler
{
    public class HealthHandler : MonoInitializable
    {
        [SerializeField] private LevelOptionsScriptable scriptable;
        
        [SerializeField] private HealthBarView healthBarView;
        
        [SerializeField] private LosePanelInstaller loseInstaller;

        private HealthOptions _options;
        private int _currentHealthCount;
        
        public override void Init()
        {
            _options = scriptable.health;
            _currentHealthCount = _options.startHealthCount;
            healthBarView.SetHearts(_options.startHealthCount, scriptable.level.timeBetweenPackSpawn);
        }
        
        public void RemoveHeart()
        {
            healthBarView.RemoveHeart();
            if (--_currentHealthCount == 0)
            {
                StartCoroutine(loseInstaller.WaitAndShow());
            }
        }
        
        public void AddHeart()
        {
            if (_currentHealthCount == _options.maxHealthCount) return;
            healthBarView.AddHeart(_options.startHealthCount / scriptable.level.timeBetweenPackSpawn);
            _currentHealthCount++;
        }
    }
}