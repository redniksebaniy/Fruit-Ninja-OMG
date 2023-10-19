using App.Scripts.UI.AnimatedViews.Game.Score;
using App.Scripts.Utilities.CameraAdapter;
using UnityEngine;
using UnityEngine.UIElements;

namespace App.Scripts.Game.Features.ScoreHandler.ScoreLabelProvider
{
    public class ScoreLabelProvider : MonoBehaviour
    {
        [SerializeField] private OrthographicCameraAdapter adapter;
        
        [SerializeField] private ScoreLabelView scorePrefab;

        [SerializeField] private ComboLabelView comboPrefab;

        public void CreateScoreLabel(Vector3 position, int value)
        {
            var newScore = Instantiate(scorePrefab, position, Quaternion.identity);
            newScore.transform.SetParent(transform);
            newScore.Init();
            newScore.SetValue(value);
        }
        
        public void CreateComboLabel(Vector3 position, int value)
        {
            var newScore = Instantiate(comboPrefab, position, Quaternion.identity);
            newScore.transform.SetParent(transform);
            newScore.Init();
            newScore.SetValue(value);
        }
    }
}