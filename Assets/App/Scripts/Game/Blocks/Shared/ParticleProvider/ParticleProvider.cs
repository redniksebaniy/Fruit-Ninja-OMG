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
            foreach (var particle in particles)
            {
                particle.transform.parent = rootObject.parent;
                particle.transform.rotation = rootObject.transform.rotation;
                particle.Play();
            }
        }
    }
    
    
}