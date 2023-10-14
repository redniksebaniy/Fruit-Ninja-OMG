using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scripts.UI.Game.View
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] private Text scoreText;
        
        [SerializeField] private Text highscoreText;
        
        [SerializeField] private HealthBarView healthBarView;


        public void SetScore(int score)
        {
            DOTween.To(() => int.Parse(scoreText.text), x => scoreText.text = x.ToString(), score, 0.5f);
        }

        public void SetHighscore(int highscore)
        {
            DOTween.To(() => int.Parse(scoreText.text), x => scoreText.text = x.ToString(), highscore, 0.5f);
        }

        public void RemoveHealth()
        {
            healthBarView.RemoveHealth();
        }

        public void AddHealth()
        {
            healthBarView.AddHealth();
        }
        
    }
}