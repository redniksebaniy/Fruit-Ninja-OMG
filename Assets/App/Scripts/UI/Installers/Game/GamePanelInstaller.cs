using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Features.ScoreHandler;
using App.Scripts.Game.Spawning.LevelHandler;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Fade;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Move;
using App.Scripts.UI.AnimatedViews.Basic.Int;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Installers.Game
{
    public class GamePanelInstaller : MonoInitializable
    {
        [SerializeField] private AnimatedCanvasFadeView gamePanel;
        
        [Header("Panel Components")]
        [SerializeField] private AnimatedIntView scoreView;

        [SerializeField] private AnimatedIntView highscoreView;

        [SerializeField] private Button pauseButton;

        [Header("On Enable Work")]
        [SerializeField] private GameObject cursor;

        [SerializeField] private LevelHandler levelHandler;
        
        [SerializeField] private ScoreHandler scoreHandler;
        
        [SerializeField] private AnimatedCanvasMoveView transitionCanvasMove;
        
        [Header("Button Work Components")]
        [SerializeField] private PausePanelInstaller pauseInstaller;

        public override void Init()
        {
            highscoreView.Init();
            scoreView.Init();
            gamePanel.Init();
            transitionCanvasMove.Init();
            
            pauseButton.onClick.AddListener(() =>
            {
                scoreHandler.SaveHighscore();
                pauseInstaller.ShowPanel();
            });
            
            ShowPanel();
            transitionCanvasMove.Hide();
        }

        public void ShowPanel()
        {
            cursor.SetActive(true);
            levelHandler.enabled = true;
            gamePanel.Show();
        }
        
        public void HidePanel()
        {
            cursor.SetActive(false);
            levelHandler.enabled = false;
            gamePanel.Hide();
        }
    }
}