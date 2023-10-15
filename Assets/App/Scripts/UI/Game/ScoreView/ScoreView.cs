using App.Scripts.Architecture.MonoInitializable;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace App.Scripts.UI.Game.ScoreView
{
    public class ScoreView : MonoInitializable
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        
        [SerializeField] [Min(0)] private float changeTime;

        public int CurrentScore { get; protected set; }

        public override void Init()
        {
            CurrentScore = 0;
            SetScore(CurrentScore);
        }

        public void SetScore(int value)
        {
            DOTween.To(() => CurrentScore, (x) => CurrentScore = x, value, changeTime)
                .OnUpdate(() => scoreText.text = CurrentScore.ToString());
        }
    }
}