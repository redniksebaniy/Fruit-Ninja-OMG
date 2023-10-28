using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Commands.TimeScale;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Fade;
using App.Scripts.UI.AnimatedViews.Basic.Int;
using UnityEngine;

namespace App.Scripts.UI.Installers.Game
{
    public class FreezePanelInstaller : MonoInitializable
    {
        [SerializeField] private AnimatedCanvasFadeView freezePanel;

        [Header("Panel Components")]
        [SerializeField] private AnimatedIntView timeView;
        
        [SerializeField] [Range(0, 1)] private float slowedTimeScale;

        [SerializeField] [Min(0)] private int freezeDuration;

        private float _currentTime;
        
        private GetTimeScaleCommand _timeScaleCommand;
        
        public override void Init()
        {
            freezePanel.Init();
            timeView.Init();

            _timeScaleCommand = new();
        }

        public void ShowPanel()
        {
            new SetTimeScaleCommand(slowedTimeScale).Execute();
            freezePanel.Show();
            _currentTime = freezeDuration;
        }

        public void HidePanel()
        {
            _timeScaleCommand.Execute();
            
            new SetTimeScaleCommand(_timeScaleCommand.TimeScale == 0 ? 0 : 1).Execute();
            freezePanel.Hide();
        }

        private void Update()
        {
            _timeScaleCommand.Execute();
            if (_currentTime == 0 || _timeScaleCommand.TimeScale == 0) return;
            
            _currentTime -= Time.unscaledDeltaTime;
            timeView.SetValue(Mathf.CeilToInt(_currentTime));
            
            if (_currentTime < 0)
            {
                _currentTime = 0;
                HidePanel();
            }
        }
    }
}