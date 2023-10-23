using App.Scripts.Architecture.Command;
using UnityEngine;

namespace App.Scripts.Commands.TimeScale
{
    public class GetTimeScaleCommand : ICommand
    {
        public float TimeScale;
        
        public void Execute()
        {
            TimeScale = Time.timeScale;
        }
    }
}