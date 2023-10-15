using System;
using UnityEngine;

namespace App.Scripts.UI.Game.HighscoreView
{
    public class HighscoreView : ScoreView.ScoreView
    {
        [SerializeField] private string HIGHSCORE_KEY = "Highscore";
        
        public override void Init()
        {
            CurrentScore = PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
            SetScore(CurrentScore);
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetInt(HIGHSCORE_KEY, CurrentScore);
        }
    }
}