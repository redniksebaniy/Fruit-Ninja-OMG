using App.Scripts.Game.Blocks.Shared.Base;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Heart
{
    public class HeartBlock : Block
    {
        [SerializeField] private Shared.ParticleProvider.ParticleProvider particleProvider;
        
        public override void Init()
        {
            particleProvider.Init();

            OnChop += (x) =>
            {
                particleProvider.PlayParticles();
            }; 
        }
    }
}