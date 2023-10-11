using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Blocks.Score.ParticleProvider.Scriptable;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.ParticleProvider
{
    public class ParticleProvider : MonoInitializable
    {
        [SerializeField] private SpriteColorScriptable infos;
        
        [SerializeField] private SpriteRenderer originalRenderer;
        
        [SerializeField] private ParticleSystem[] particles;
        
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

        public void PlayParticles()
        {
            foreach (var particle in particles)
            {
                particle.transform.parent = originalRenderer.transform.parent;
                particle.transform.rotation = originalRenderer.transform.rotation;
                particle.Play();
            }
        }
    }
    
    
}