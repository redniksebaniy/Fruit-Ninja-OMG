using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.UI.AnimatedViews.Base.Button;
using App.Scripts.UI.AnimatedViews.Base.Int;
using App.Scripts.UI.Commands.Data.Load;
using App.Scripts.UI.Commands.Data.Types;
using App.Scripts.UI.Commands.ExitGame;
using App.Scripts.UI.Commands.LoadScene;
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
        
        public override void Init()
        {
            var command = new LoadDataCommand<PlayerRecords>( "App/Data", "Records.json");
            command.Execute();
            highscoreView.Init();
            highscoreView.SetValue(command.Data.Highscore);
            
            playButton.onClick.AddListener(() =>
            {
                new LoadSceneCommand("Game").Execute();
            });
            
            exitButton.onClick.AddListener(() =>
            {
                new ExitGameCommand().Execute();
            });
            
            menuPanel.SetActive(true);
        }
    }
}