using App.Scripts.Architecture.Command;
using UnityEngine;

namespace App.Scripts.UI.Commands.SetTimeScale
{
    public class SetTimeScaleCommand : ICommand
    {
        private float _timeScale;

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