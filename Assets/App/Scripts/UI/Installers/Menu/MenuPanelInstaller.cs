using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Commands.Data.Load;
using App.Scripts.Commands.Data.Types;
using App.Scripts.Commands.ExitGame;
using App.Scripts.Commands.LoadScene;
using App.Scripts.UI.AnimatedViews.Base.Button;
using App.Scripts.UI.AnimatedViews.Base.Int;
using App.Scripts.UI.AnimatedViews.Base.Panel;
using UnityEngine;

namespace App.Scripts.UI.Installers.Menu
{
    public class MenuPanelInstaller : MonoInitializable
    {
        [SerializeField] private GameObject menuPanel;
        
        [Header("Panel Components")]
        [SerializeField] private AnimatedIntView highscoreView;

        [SerializeField] private AnimatedButtonView playButton;
        
        [SerializeField] private AnimatedButtonView exitButton;
        
        [Header("On Enable Work")]
        [SerializeField] private AnimatedPanelView transitionPanel;
        
        public override void Init()
        {
            var command = new LoadDataCommand<PlayerRecords>( "App/Data", "Records.json");
            command.Execute();
            highscoreView.Init();
            highscoreView.SetValue(command.Data.Highscore);
            
            playButton.onClick.AddListener(() =>
            {
                transitionPanel.ShowPanel(() => new LoadSceneCommand("Game").Execute());
                
            });
            
            exitButton.onClick.AddListener(() =>
            {
                transitionPanel.ShowPanel(() => new ExitGameCommand().Execute());
            });

            transitionPanel.Init();
            ShowPanel();
            transitionPanel.HidePanel();
        }

        public void ShowPanel()
        {
            menuPanel.SetActive(true);
        }
    }
}