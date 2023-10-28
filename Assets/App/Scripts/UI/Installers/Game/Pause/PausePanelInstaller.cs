using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Commands.LoadScene;
using App.Scripts.Commands.LoadScene.Scriptable;
using App.Scripts.Commands.TimeScale;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Fade;
using App.Scripts.UI.AnimatedViews.Basic.CanvasGroup.Move;
using UnityEngine;
using UnityEngine.UI;
using Cursor = App.Scripts.Input.Cursor.Cursor;

namespace App.Scripts.UI.Installers.Game.Pause
{
    public class PausePanelInstaller : MonoInitializable
    {
        [SerializeField] private AnimatedCanvasFadeView pausePanel;
        
        [Header("Panel Components")]
        [SerializeField] private Button continueButton;

        [SerializeField] private Button menuButton;

        [Header("On Enable Work")]
        [SerializeField] private Cursor cursor;

        [Header("Button Work Components")] 
        [SerializeField] private SceneLoaderScriptable sceneScriptable;
        
        [SerializeField] private AnimatedCanvasMoveView transitionPanel;

        private float _currentTimeScale;
        
        public override void Init()
        {
            pausePanel.Init();
            
            continueButton.onClick.AddListener(() =>
            {
                cursor.SetCursorState(false);
                cursor.gameObject.SetActive(true);
                HidePanel();
            });
            
            menuButton.onClick.AddListener(() =>
            {
                transitionPanel.Show(() =>
                {
                    new SetTimeScaleCommand(1).Execute();
                    new LoadSceneCommand(sceneScriptable.menuSceneName).Execute();
                });
            });
        }
        
        public void ShowPanel()
        {
            var command = new GetTimeScaleCommand();
            command.Execute();
            _currentTimeScale = command.TimeScale;
            
            new SetTimeScaleCommand(0).Execute();
            
            pausePanel.Show();
        }
        
        public void HidePanel()
        {
            new SetTimeScaleCommand(_currentTimeScale).Execute();
            
            pausePanel.Hide();
        }
    }
}