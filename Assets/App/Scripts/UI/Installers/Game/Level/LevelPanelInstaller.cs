using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Features.ScoreHandler;
using App.Scripts.Game.Spawning.LevelHandler;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Fade;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Move;
using App.Scripts.UI.AnimatedViews.Basic.Int;
using App.Scripts.UI.Installers.Game.Pause;
using UnityEngine;
using UnityEngine.UI;
using Cursor = App.Scripts.Input.Cursor.Cursor;

namespace App.Scripts.UI.Installers.Game.Level
{
    public class LevelPanelInstaller : MonoInitializable
    {
        [SerializeField] private AnimatedCanvasFadeView gamePanel;
        
        [Header("Panel Components")]
        [SerializeField] private AnimatedIntView scoreView;

        [SerializeField] private AnimatedIntView highscoreView;

        [SerializeField] private Button pauseButton;

        [Header("On Enable Work")]
        [SerializeField] private Cursor cursor;

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
                cursor.SetCursorState(false);
                cursor.gameObject.SetActive(false);
                scoreHandler.SaveHighscore();
                pauseInstaller.ShowPanel();
            });
            
            ShowPanel();
            transitionCanvasMove.Hide();
        }

        public void ShowPanel()
        {
            cursor.SetCursorState(false);
            cursor.gameObject.SetActive(true);
            levelHandler.enabled = true;
            gamePanel.Show();
        }
        
        public void HidePanel()
        {
            cursor.SetCursorState(false);
            cursor.gameObject.SetActive(false);
            levelHandler.enabled = false;
            gamePanel.Hide();
        }
    }
}