using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Commands.Data.Load;
using App.Scripts.Commands.Data.Save;
using App.Scripts.Commands.Data.Types;
using App.Scripts.Game.Features.ScoreHandler.Scriptable;
using App.Scripts.UI.AnimatedViews.Basic.Int;
using App.Scripts.UI.ScoreLabelProvider;
using UnityEngine;

namespace App.Scripts.Game.Features.ScoreHandler
{
    public class ScoreHandler : MonoInitializable
    {
        [SerializeField] private ScoreOptionsScriptable scriptable;
        
        [SerializeField] private AnimatedIntView scoreView;
        
        [SerializeField] private AnimatedIntView highscoreView;

        [SerializeField] private ScoreLabelProvider scoreLabelProvider;

        private ScoreOptions _options;
        
        private int _comboCounter;

        private float _timeFromLastChop;
        
        private Vector2 _labelPosition;
        
        public int CurrentScore { get; private set; }
        public int CurrentHighscore { get; private set; }

        public override void Init()
        {
            _options = scriptable.options;
            var command = new LoadDataCommand<PlayerRecords>("Records.json", "App", "Data");
            command.Execute();
            
            CurrentHighscore = command.Data.Highscore;
            CurrentScore = 0;
            
            scoreView.SetValue(CurrentScore);
            highscoreView.SetValue(CurrentHighscore);
        }

        private void Update()
        {
            _timeFromLastChop += Time.deltaTime;

            if (IsCombo()) return;
            
            if (_comboCounter > 1)
            {
                AddValue(_options.scoreAmount * _comboCounter);
                scoreLabelProvider.CreateComboLabel(_labelPosition, _comboCounter);
            }
            
            _comboCounter = 0;
        }
        
        public void AddScore(Vector2 labelPosition)
        {
            _timeFromLastChop = 0;

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
        
        private bool IsCombo() => _timeFromLastChop < _options.comboMaxTime;

        public void SaveHighscore()
        {
            PlayerRecords data = new();
            data.Highscore = CurrentHighscore;

            new SaveDataCommand<PlayerRecords>(data,"Records.json", "App", "Data").Execute();
        }
        
        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus) SaveHighscore();
        }
    }
}