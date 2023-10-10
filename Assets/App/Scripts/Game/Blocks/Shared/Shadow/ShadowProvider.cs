using App.Scripts.Architecture.MonoInitializable;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Shadow
{
    public class ShadowProvider : MonoInitializable
    {
        [Header("Original Sprite Renderer")]
        [SerializeField] private SpriteRenderer originalRenderer;
        
        [SerializeField] private SpriteRenderer shadowRenderer;
        
        [Header("Shadow Options")]
        [SerializeField] private Vector3 shadowOffset;
        
        [SerializeField] [Min(1)] private float offsetMultiplier;

        [SerializeField] [Range(0, 1)] private float shadowIntensity;

        private Transform _origTransform;
        
        public override void Init()
        {
            shadowRenderer.sprite = originalRenderer.sprite;
            
            Color shadowColor = Color.black;
            shadowColor.a = shadowIntensity;
            shadowRenderer.color = shadowColor;

            _origTransform = originalRenderer.transform;
        }

        private void Update()
        {
            UpdateShadow();
        }

        private void UpdateShadow()
        {
            float scale = _origTransform.lossyScale.z;
            float currentOffsetMultiplier = Mathf.Max(0.01f, 1 + (scale - 1) * offsetMultiplier);
            shadowRenderer.transform.position = _origTransform.position + shadowOffset * currentOffsetMultiplier;
        }
    }
}