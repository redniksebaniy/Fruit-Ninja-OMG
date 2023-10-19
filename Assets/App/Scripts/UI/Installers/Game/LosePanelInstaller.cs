using System.Collections;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Features.ScoreHandler;
using App.Scripts.Game.Spawning.BlockProvider;
using App.Scripts.UI.AnimatedViews.Base.Button;
using App.Scripts.UI.AnimatedViews.Base.CanvasGroup;
using App.Scripts.UI.AnimatedViews.Base.Int;
using App.Scripts.UI.AnimatedViews.Base.Panel;
using App.Scripts.UI.Commands.LoadScene;
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
        
        public override void Init()
        {
            losePanel.Init();
            loseContent.Init();
            
            highscoreView.Init();
            scoreView.Init();
            
            restartButton.onClick.AddListener(() =>
            {
                new LoadSceneCommand("Game").Execute();
            });
            menuButton.onClick.AddListener(() =>
            {
                new LoadSceneCommand("Menu").Execute();
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
            scoreView.SetValueAnimated(scoreHandler.CurrentScore);
            highscoreView.SetValueAnimated(scoreHandler.CurrentHighscore);
            
            losePanel.ShowCanvasGroup();
            loseContent.ShowPanel();
        }
    }
}