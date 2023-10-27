using System;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.UI.AnimatedViews.Game.Score;
using App.Scripts.Utilities.CameraAdapter;
using UnityEngine;

namespace App.Scripts.UI.ScoreLabelProvider
{
    public class ScoreLabelProvider : MonoInitializable
    {
        [SerializeField] private OrthographicCameraAdapter adapter;

        [SerializeField] [Range(0, 1)] private float appearWidthPercent;
        
        [SerializeField] [Range(0, 1)] private float appearHeightPercent;
        
        [SerializeField] private ScoreLabelView scorePrefab;

        [SerializeField] private ComboLabelView comboPrefab;

        private Rect _appearRect;
        
        public override void Init()
        {
            Vector3 rightTop = new Vector3(appearWidthPercent, appearHeightPercent);
            Vector3 leftBottom = rightTop * -1;
            adapter.GetAdaptedPositionByPercent(ref rightTop);
            adapter.GetAdaptedPositionByPercent(ref leftBottom);

            _appearRect = new Rect(leftBottom, rightTop - leftBottom);
        }
        
        public void CreateScoreLabel(Vector3 position, int value)
        {
            var newScore = Instantiate(scorePrefab, FitInScreen(position), Quaternion.identity);
            newScore.transform.SetParent(transform);
            newScore.Init();
            newScore.SetValue(value);
        }
        
        public void CreateComboLabel(Vector3 position, int value)
        {
            var newScore = Instantiate(comboPrefab, FitInScreen(position), Quaternion.identity);
            newScore.transform.SetParent(transform);
            newScore.Init();
            newScore.SetValue(value);
        }

        private Vector3 FitInScreen(Vector3 position)
        {
            float x = Math.Clamp(position.x, _appearRect.x, _appearRect.x + _appearRect.width);
            float y = Math.Clamp(position.y, _appearRect.y, _appearRect.y + _appearRect.height);

            return new Vector3(x, y, position.z);
        }
    }
}