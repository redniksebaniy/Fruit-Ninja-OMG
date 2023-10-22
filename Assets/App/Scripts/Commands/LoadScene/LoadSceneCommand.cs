using App.Scripts.Architecture.Command;
using UnityEngine.SceneManagement;

namespace App.Scripts.Commands.LoadScene
{
    public class LoadSceneCommand : ICommand
    {
        private readonly string _sceneName;
        
        public LoadSceneCommand(string value)
        {
            _sceneName = value;
        }
        
        public void Execute()
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}