using System.Collections;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Commands.LoadScene;
using App.Scripts.Game.Features.ScoreHandler;
using App.Scripts.Game.Spawning.BlockProvider;
using App.Scripts.UI.AnimatedViews.Base.Button;
using App.Scripts.UI.AnimatedViews.Base.CanvasGroup;
using App.Scripts.UI.AnimatedViews.Base.Int;
using App.Scripts.UI.AnimatedViews.Base.Panel;
using UnityEngine;

namespace App.Scripts.UI.Installers.Game
{
    public class LosePanelInstaller : MonoInitializable
    {
        [SerializeField] private AnimatedCanvasGroupView losePanel;
        [SerializeField] private AnimatedPanelView loseContent;
        
        [Header("Panel Components")]
        [SerializeField] private AnimatedIntView scoreView;
        
        [SerializeField] private AnimatedIntView highscoreView;
        
        [SerializeField] private AnimatedButtonView restartButton;

        [SerializeField] private AnimatedButtonView menuButton;
        
        [Header("On Enable Work")]
        [SerializeField] private ScoreHandler scoreHandler;

        [SerializeField] private BlockProvider blockProvider;

        [SerializeField] private GamePanelInstaller gameInstaller;
        
        [Header("Button Work Components")]
        [SerializeField] private AnimatedPanelView transitionPanel;
        
        public override void Init()
        {
            losePanel.Init();
            loseContent.Init();
            
            highscoreView.Init();
            scoreView.Init();
            
            restartButton.onClick.AddListener(() =>
            {
                transitionPanel.ShowPanel(() => new LoadSceneCommand("Game").Execute());
            });
            menuButton.onClick.AddListener(() =>
            {
                transitionPanel.ShowPanel(() => new LoadSceneCommand("Menu").Execute());
            });
        }

        public IEnumerator WaitAndShow()
        {
            gameInstaller.HidePanel();
            yield return new WaitUntil(() => blockProvider.SpawnedBlocks.Count == 0);
            yield return new WaitForSeconds(1);
            ShowPanel();
        }

        public void ShowPanel()
        {
            losePanel.ShowCanvasGroup(() =>
            {
                loseContent.ShowPanel();
                scoreView.SetValue(0);
                highscoreView.SetValue(scoreHandler.CurrentHighscore);
                scoreView.SetValueAnimated(scoreHandler.CurrentScore);
            });
        }
    }
}