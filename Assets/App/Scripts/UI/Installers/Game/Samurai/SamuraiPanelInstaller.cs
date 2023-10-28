using App.Scripts.Game.Features.HealthHandler;
using App.Scripts.Game.Features.TemporaryEvent;
using App.Scripts.Game.Spawning.LevelHandler;
using App.Scripts.Game.Spawning.LevelHandler.Scriptable;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Fade;
using UnityEngine;

namespace App.Scripts.UI.Installers.Game.Samurai
{
    public class SamuraiPanelInstaller : TemporaryEvent
    {
        [SerializeField] private AnimatedCanvasFadeView samuraiPanel;
        
        [SerializeField] private LevelOptionsScriptable scriptable;
        
        [SerializeField] private LevelHandler levelHandler;

        [SerializeField] private HealthHandler healthHandler;
        
        public override void Init()
        {
            samuraiPanel.Init();
            timeView.Init();
        }

        public override void StartEvent()
        {
            samuraiPanel.Show();
            levelHandler.SetLevelOptions(scriptable.level);
            healthHandler.IsInvulnerable = true;
            
            CurrentTime = eventDuration;
        }

        public override void EndEvent()
        {
            samuraiPanel.Hide();
            healthHandler.IsInvulnerable = false;
            levelHandler.ResetLevelOptions();
        }
    }
}