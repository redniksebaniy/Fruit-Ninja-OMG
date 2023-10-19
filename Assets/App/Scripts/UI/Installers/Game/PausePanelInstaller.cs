using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Features.ScoreHandler;
using App.Scripts.Game.Spawning.LevelHandler;
using App.Scripts.UI.AnimatedViews.Base.Button;
using App.Scripts.UI.AnimatedViews.Base.CanvasGroup;
using App.Scripts.UI.Commands.LoadScene;
using App.Scripts.UI.Commands.SetTimeScale;
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
        
        public override void Init()
        {
            continueButton.onClick.AddListener(() =>
            {
                HidePanel();
            });
            
            menuButton.onClick.AddListener(() =>
            {
                new SetTimeScaleCommand(1).Execute();
                new LoadSceneCommand("Menu").Execute();
            });
            
            pausePanel.Init();
        }

        public void ShowPanel()
        {
            cursor.SetActive(false);
            levelHandler.enabled = false;
            scoreHandler.SaveHighscore();
            new SetTimeScaleCommand(0).Execute();
            
            pausePanel.ShowCanvasGroup();
        }
        
        public void HidePanel()
        {
            cursor.SetActive(true);
            levelHandler.enabled = true;
            new SetTimeScaleCommand(1).Execute();
            
            pausePanel.HideCanvasGroup();
        }
    }
}