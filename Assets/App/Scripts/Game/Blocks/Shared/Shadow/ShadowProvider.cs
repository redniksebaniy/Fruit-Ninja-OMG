using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Blocks.Shared.Shadow.Scriptable;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Shadow
{
    public class ShadowProvider : MonoInitializable
    {
        [Header("Original Sprite Renderer")]
        [SerializeField] private SpriteRenderer originalRenderer;
        
        [SerializeField] private SpriteRenderer shadowRenderer;

        [SerializeField] private ShadowOptionsScriptable scriptable;

        private Transform _origTransform;
        
        public override void Init()
        {
            shadowRenderer.sprite = originalRenderer.sprite;
            
            var shadowColor = Color.black;
            shadowColor.a = scriptable.shadowIntensity;
            shadowRenderer.color = shadowColor;

            _origTransform = originalRenderer.transform;
        }

        private void Update()
        {
            UpdateShadow();
        }

        private void UpdateShadow()
        {
            var offsetMultiplier = 1 + (_origTransform.lossyScale.z - 1) * scriptable.offsetMultiplier;
            if (offsetMultiplier < 0) offsetMultiplier = 0;
            
            shadowRenderer.transform.position = _origTransform.position + scriptable.shadowOffset * offsetMultiplier;
        }
    }
}