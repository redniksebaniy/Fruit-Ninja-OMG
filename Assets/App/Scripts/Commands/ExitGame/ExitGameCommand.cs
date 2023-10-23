using App.Scripts.Architecture.Command;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

namespace App.Scripts.Commands.ExitGame
{
    public class ExitGameCommand : ICommand
    {
        public void Execute()
        {
            DOTween.KillAll();
            
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}