using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Features.ScoreHandler.Scriptable;
using App.Scripts.UI.AnimatedViews.Base.Int;
using App.Scripts.UI.Commands.Data.Load;
using App.Scripts.UI.Commands.Data.Save;
using App.Scripts.UI.Commands.Data.Types;
using UnityEngine;

namespace App.Scripts.Game.Features.ScoreHandler
{
    public class ScoreHandler : MonoInitializable
    {
        [SerializeField] private ScoreOptionsScriptable scriptable;
        
        [SerializeField] private AnimatedIntView scoreView;
        
        [SerializeField] private AnimatedIntView highscoreView;

        [SerializeField] private ScoreLabelProvider.ScoreLabelProvider scoreLabelProvider;

        private ScoreOptions _options;
        
        private int _comboCounter = 0;

        private float _timeFromlastChop;
        
        private Vector2 _labelPosition;
        
        public int CurrentScore { get; private set; }
        public int CurrentHighscore { get; private set; }

        public override void Init()
        {
            _options = scriptable.options;
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

            if (!IsCombo() && _comboCounter > 1)
            {
                AddValue(_options.scoreAmount * _comboCounter);
                scoreLabelProvider.CreateComboLabel(_labelPosition, _comboCounter);
                _comboCounter = 0;
            }
        }
        
        public void AddScore(Vector2 labelPosition)
        {
            _timeFromlastChop = 0;

            _labelPosition = labelPosition;
            scoreLabelProvider.CreateScoreLabel(_labelPosition,_options.scoreAmount);
            
            AddValue(_options.scoreAmount);
            IncreaseComboCounter();
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
        
        private void IncreaseComboCounter()
        {
            _comboCounter += IsCombo() ? 1 : 0;
            _comboCounter = _comboCounter > _options.comboMaxCount ? _options.comboMaxCount : _comboCounter;
        }
        
        private bool IsCombo()
        {
            return _timeFromlastChop < _options.comboMaxTime;
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