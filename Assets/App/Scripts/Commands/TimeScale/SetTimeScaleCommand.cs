using App.Scripts.Architecture.Command;
using UnityEngine;

namespace App.Scripts.Commands.TimeScale
{
    public class SetTimeScaleCommand : ICommand
    {
        private readonly float _timeScale;

        public SetTimeScaleCommand(float value)
        {
            _timeScale = value;
        }
        
        public void Execute()
        {
            Time.timeScale = _timeScale;
        }
    }
}