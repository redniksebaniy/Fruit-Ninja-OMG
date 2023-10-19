using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Features.ScoreHandler;
using App.Scripts.Game.Spawning.LevelHandler;
using App.Scripts.UI.AnimatedViews.Base.Button;
using App.Scripts.UI.AnimatedViews.Base.CanvasGroup;
using App.Scripts.UI.AnimatedViews.Base.Int;
using App.Scripts.UI.AnimatedViews.Game.HealthBarView;
using UnityEngine;

namespace App.Scripts.UI.Installers.Game
{
    public class GamePanelInstaller : MonoInitializable
    {
        [SerializeField] private AnimatedCanvasGroupView gamePanel;
        
        [Header("Panel Components")]
        [SerializeField] private HealthBarView healthBarView;

        [SerializeField] private AnimatedIntView scoreView;

        [SerializeField] private AnimatedIntView highscoreView;

        [SerializeField] private AnimatedButtonView pauseButton;

        [Header("On Enable Work")]
        [SerializeField] private GameObject cursor;

        [SerializeField] private LevelHandler levelHandler;
        
        [SerializeField] private ScoreHandler scoreHandler;
        
        [Header("Button Work Components")]
        [SerializeField] private PausePanelInstaller pauseInstaller;
        

        public override void Init()
        {
            //health bar
            
            highscoreView.Init();
            scoreView.Init();
            
            pauseButton.onClick.AddListener(() =>
            {
                pauseInstaller.ShowPanel();
            });

            gamePanel.Init();

            ShowPanel();
        }

        public void ShowPanel()
        {
            gamePanel.ShowCanvasGroup();
        }
        
        public void HidePanel()
        {
            cursor.SetActive(false);
            levelHandler.enabled = false;
            scoreHandler.SaveHighscore();
            gamePanel.HideCanvasGroup();
        }
    }
}