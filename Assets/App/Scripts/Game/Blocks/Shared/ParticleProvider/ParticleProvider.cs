using App.Scripts.Architecture.MonoInitializable;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.ParticleProvider
{
    public class ParticleProvider : MonoInitializable
    {
        [SerializeField] protected Transform rootObject;
        [SerializeField] protected ParticleSystem[] particles;

        public override void Init() { }

        public void PlayParticles()
        {
            Transform particleTransform;
            foreach (var particle in particles)
            {
                particleTransform = particle.transform;
                particleTransform.SetParent(rootObject.parent);
                particleTransform.rotation = rootObject.transform.rotation;
                particle.Play();
            }
        }
    }
    
    
}