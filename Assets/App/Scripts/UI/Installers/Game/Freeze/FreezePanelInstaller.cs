using App.Scripts.Commands.TimeScale;
using App.Scripts.Game.Features.TemporaryEvent;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Fade;
using App.Scripts.UI.AnimatedViews.Basic.ImageShader;
using App.Scripts.Utilities.CameraEffectController;
using UnityEngine;

namespace App.Scripts.UI.Installers.Game.Freeze
{
    public class FreezePanelInstaller : TemporaryEvent
    {
        [SerializeField] private AnimatedCanvasFadeView freezePanel;
        
        [SerializeField] private AnimatedCanvasFadeView backPanel;
        
        [SerializeField] [Range(0, 1)] private float slowedTimeScale;

        [SerializeField] private CameraEffectController cameraEffect;
        
        [SerializeField] private AnimatedImageShaderView[] shaderViews;
        
        public override void Init()
        {
            freezePanel.Init();
            backPanel.Init();
            timeView.Init();

            for (int i = 0; i < shaderViews.Length; i++)
            {
                shaderViews[i].Init();
                shaderViews[i].ActivateShader();
            }
        }

        public override void StartEvent()
        {
            CurrentTime = eventDuration;
            new SetTimeScaleCommand(slowedTimeScale).Execute();

            freezePanel.Show(() => cameraEffect.enabled = true);
            backPanel.Show();
        }

        public override void EndEvent()
        {
            TimeScaleCommand.Execute();
            new SetTimeScaleCommand(TimeScaleCommand.TimeScale == 0 ? 0 : 1).Execute();
            
            freezePanel.Hide();
            backPanel.Hide();
            cameraEffect.enabled = false;
        }
    }
}