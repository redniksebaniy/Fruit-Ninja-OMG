using App.Scripts.Architecture.Command;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.UI.Commands.ExitGame
{
    public class ExitGameCommand : ICommand
    {
        public void Execute()
        {
            DOTween.KillAll();
            Application.Quit();
        }
    }
}