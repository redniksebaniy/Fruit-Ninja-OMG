using App.Scripts.Game.Blocks.Score.FruitParticleProvider.Scriptable;
using App.Scripts.Game.Blocks.Shared.ParticleProvider;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Score.FruitParticleProvider
{
    public class FruitParticleProvider : ParticleProvider
    {
        [SerializeField] private SpriteColorScriptable infos;
        
        [SerializeField] private SpriteRenderer originalRenderer;
        
        private Color _currentColor;
        
        public override void Init()
        {
            _currentColor = GetCurrentColor();
            SetParticlesColor(_currentColor);
        }

        private Color GetCurrentColor()
        {
            var originalSprite = originalRenderer.sprite;

            foreach (var info in infos.spriteColorsInfos)
            {
                if (originalSprite.Equals(info.sprite))
                {
                    return info.color;
                }
            }

            return Color.black;
        }

        private void SetParticlesColor(Color color)
        {
            foreach (var particle in particles)
            {
                var module = particle.main;
                module.startColor = color;
            }
        }
    }
}