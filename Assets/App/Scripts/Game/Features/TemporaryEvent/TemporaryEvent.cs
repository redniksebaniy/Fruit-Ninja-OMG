using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Commands.TimeScale;
using App.Scripts.UI.AnimatedViews.Basic.Int;
using UnityEngine;

namespace App.Scripts.Game.Features.TemporaryEvent
{
    public abstract class TemporaryEvent : MonoInitializable
    {
        [SerializeField] [Min(0)] protected float eventDuration;

        [SerializeField] protected AnimatedIntView timeView;
        
        protected readonly GetTimeScaleCommand TimeScaleCommand = new();

        protected float CurrentTime;
        
        private void Update()
        {
            TimeScaleCommand.Execute();
            if (CurrentTime == 0 || TimeScaleCommand.TimeScale == 0) return;
            
            CurrentTime -= Time.unscaledDeltaTime;
            timeView.SetValue(Mathf.CeilToInt(CurrentTime));
            
            if (CurrentTime < 0)
            {
                CurrentTime = 0;
                EndEvent();
            }
        }

        public abstract void StartEvent();
        public abstract void EndEvent();
    }
}