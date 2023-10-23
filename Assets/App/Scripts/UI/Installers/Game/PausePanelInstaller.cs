using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Commands.LoadScene;
using App.Scripts.Commands.TimeScale;
using App.Scripts.Game.Features.ScoreHandler;
using App.Scripts.Game.Spawning.LevelHandler;
using App.Scripts.UI.AnimatedViews.Base.Button;
using App.Scripts.UI.AnimatedViews.Base.CanvasGroup;
using App.Scripts.UI.AnimatedViews.Base.Panel;
using UnityEngine;

namespace App.Scripts.UI.Installers.Game
{
    public class PausePanelInstaller : MonoInitializable
    {
        [SerializeField] private AnimatedCanvasGroupView pausePanel;
        
        [Header("Panel Components")]
        [SerializeField] private AnimatedButtonView continueButton;

        [SerializeField] private AnimatedButtonView menuButton;

        [Header("On Enable Work")]
        [SerializeField] private GameObject cursor;

        [SerializeField] private LevelHandler levelHandler;
        
        [SerializeField] private ScoreHandler scoreHandler;
        
        [Header("Button Work Components")]
        [SerializeField] private AnimatedPanelView transitionPanel;

        private float _currentTimeScale;
        
        public override void Init()
        {
            continueButton.onClick.AddListener(() =>
            {
                HidePanel();
            });
            
            menuButton.onClick.AddListener(() =>
            {
                transitionPanel.ShowPanel(() =>
                {
                    new SetTimeScaleCommand(1).Execute();
                    new LoadSceneCommand("Menu").Execute();
                });
            });
            
            pausePanel.Init();
        }

        public void ShowPanel()
        {
            cursor.SetActive(false);
            levelHandler.enabled = false;
            scoreHandler.SaveHighscore();
            
            var command = new GetTimeScaleCommand();
            command.Execute();
            _currentTimeScale = command.TimeScale;
            
            new SetTimeScaleCommand(0).Execute();
            
            pausePanel.ShowCanvasGroup();
        }
        
        public void HidePanel()
        {
            cursor.SetActive(true);
            levelHandler.enabled = true;
            new SetTimeScaleCommand(_currentTimeScale).Execute();
            
            pausePanel.HideCanvasGroup();
        }
    }
}