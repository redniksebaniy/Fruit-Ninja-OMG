using System.Collections;
using App.Scripts.Architecture.EntryPoint;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Commands.LoadScene;
using App.Scripts.Commands.LoadScene.Scriptable;
using App.Scripts.Game.Features.ScoreHandler;
using App.Scripts.Game.Spawning.BlockProvider;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Fade;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Move;
using App.Scripts.UI.AnimatedViews.Basic.Int;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Installers.Game
{
    public class LosePanelInstaller : MonoInitializable
    {
        [SerializeField] private AnimatedCanvasFadeView losePanel;
        
        [SerializeField] private AnimatedCanvasMoveView loseContent;
        
        [Header("Panel Components")]
        [SerializeField] private AnimatedIntView scoreView;
        
        [SerializeField] private AnimatedIntView highscoreView;
        
        [SerializeField] private Button restartButton;

        [SerializeField] private Button menuButton;
        
        [Header("On Enable Work")]
        [SerializeField] private ScoreHandler scoreHandler;

        [SerializeField] private BlockProvider blockProvider;

        [SerializeField] private GamePanelInstaller gameInstaller;
        
        [Header("Button Work Components")]
        [SerializeField] private SceneLoaderScriptable sceneScriptable;
        
        [SerializeField] private AnimatedCanvasMoveView transitionCanvasMove;

        [SerializeField] private AdditionalPoint levelPoint;
        
        public override void Init()
        {
            losePanel.Init();
            loseContent.Init();
            
            highscoreView.Init();
            scoreView.Init();
            
            restartButton.onClick.AddListener(() =>
            {
                loseContent.Hide(() => losePanel.Hide(() =>
                    {
                        levelPoint.Init();
                        gameInstaller.ShowPanel();
                    })
                );
            });
            
            menuButton.onClick.AddListener(() =>
            {
                loseContent.Interactable = true;
                
                transitionCanvasMove.Show(() =>
                {
                    new LoadSceneCommand(sceneScriptable.menuSceneName).Execute();
                });
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
            losePanel.Show(() =>
            {
                loseContent.Show();
                scoreView.SetValue(0);
                scoreView.SetValueAnimated(scoreHandler.CurrentScore);
                highscoreView.SetValue(scoreHandler.CurrentHighscore);
                scoreHandler.SaveHighscore();
            });
        }
    }
}