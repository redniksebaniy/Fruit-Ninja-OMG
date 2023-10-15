using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.UI.Game.HighscoreView;
using App.Scripts.UI.Game.ScoreView;
using UnityEngine;

namespace App.Scripts.Game.Features.ScoreHandler
{
    public class ScoreHandler : MonoBehaviour
    {
        [SerializeField] private ScoreView scoreView;
        
        [SerializeField] private HighscoreView highscoreView;
        
        [SerializeField] [Min(0)] private int scoreAmount;

        [SerializeField] [Min(0)] private float comboMaxTime;
        
        [SerializeField] [Min(0)] private int comboMaxCount;
        
        private int _comboCounter = 1;

        private float _previousChopTime;

        private int _currentScore;
        private int CurrentScore
        {
            get { return _currentScore; }
            set
            {
                _currentScore = value;
                scoreView.SetScore(value);
                if (highscoreView.CurrentScore < value)
                {
                    highscoreView.SetScore(value);
                }
            }
        }
        
        public void AddScore()
        {
            UpdateComboCounter();
            _previousChopTime = Time.time;
            
            CurrentScore += scoreAmount * _comboCounter; 
        }

        private void UpdateComboCounter()
        {
            _comboCounter = IsCombo() ? _comboCounter + 1 : 1;
            _comboCounter = _comboCounter > comboMaxCount ? comboMaxCount : _comboCounter;
        }
        
        private bool IsCombo()
        {
            return Time.time - _previousChopTime < comboMaxTime;
        }
    }
}