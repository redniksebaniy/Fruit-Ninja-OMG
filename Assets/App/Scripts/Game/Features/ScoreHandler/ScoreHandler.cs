using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.UI.AnimatedViews.Base.Int;
using App.Scripts.UI.Commands.Data.Load;
using App.Scripts.UI.Commands.Data.Save;
using App.Scripts.UI.Commands.Data.Types;
using UnityEngine;

namespace App.Scripts.Game.Features.ScoreHandler
{
    public class ScoreHandler : MonoInitializable
    {
        [SerializeField] private AnimatedIntView scoreView;
        
        [SerializeField] private AnimatedIntView highscoreView;
        
        [SerializeField] [Min(0)] private int scoreAmount;

        [SerializeField] [Min(0)] private float comboMaxTime;
        
        [SerializeField] [Min(0)] private int comboMaxCount;
        
        private int _comboCounter = 1;

        private float _timeFromlastChop;
        
        private Vector2 _labelPosition;
        
        public int CurrentScore { get; private set; }
        public int CurrentHighscore { get; private set; }

        public override void Init()
        {
            var command = new LoadDataCommand<PlayerRecords>( "App/Data", "Records.json");
            command.Execute();
            
            CurrentHighscore = command.Data.Highscore;
            CurrentScore = 0;
            
            scoreView.SetValue(CurrentScore);
            highscoreView.SetValue(CurrentHighscore);
        }

        private void Update()
        {
            _timeFromlastChop += Time.deltaTime;
        }
        
        public void AddScore(Vector2 labelPosition)
        {
            UpdateComboCounter();
            _timeFromlastChop = 0;

            _labelPosition = labelPosition;
            
            AddValue(scoreAmount);
        }

        private void AddValue(int amount)
        {
            CurrentScore += amount;
            scoreView.SetValueAnimated(CurrentScore);
            
            if (CurrentHighscore < CurrentScore)
            {
                CurrentHighscore = CurrentScore;
                highscoreView.SetValueAnimated(CurrentHighscore);
            }
        }
        
        private void UpdateComboCounter()
        {
            _comboCounter = IsCombo() ? _comboCounter + 1 : 1;
            _comboCounter = _comboCounter > comboMaxCount ? comboMaxCount : _comboCounter;
        }
        
        private bool IsCombo()
        {
            return _timeFromlastChop < comboMaxTime;
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                SaveHighscore();
            }
        }

        public void SaveHighscore()
        {
            PlayerRecords data = new();
            data.Highscore = CurrentHighscore;

            new SaveDataCommand<PlayerRecords>(data, "App/Data", "Records.json").Execute();
        }
    }
}