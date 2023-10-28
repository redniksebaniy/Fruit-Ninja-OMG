using App.Scripts.Commands.TimeScale;
using App.Scripts.Game.Features.TemporaryEvent;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Fade;
using UnityEngine;

namespace App.Scripts.UI.Installers.Game.Freeze
{
    public class FreezePanelInstaller : TemporaryEvent
    {
        [SerializeField] private AnimatedCanvasFadeView freezePanel;

        [SerializeField] [Range(0, 1)] private float slowedTimeScale;
        
        public override void Init()
        {
            freezePanel.Init();
            timeView.Init();
        }

        public override void StartEvent()
        {
            CurrentTime = eventDuration;
            new SetTimeScaleCommand(slowedTimeScale).Execute();
            freezePanel.Show();
        }

        public override void EndEvent()
        {
            TimeScaleCommand.Execute();
            
            new SetTimeScaleCommand(TimeScaleCommand.TimeScale == 0 ? 0 : 1).Execute();
            freezePanel.Hide();
        }
    }
}