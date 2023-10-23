using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.ParticleProvider;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Bomb
{
    public class BombBlock : Block
    {
        [SerializeField] private ParticleProvider particleProvider;
        
        public override void Init()
        {
            particleProvider.Init();

            OnChop += (x) =>
            {
                particleProvider.PlayParticles();
            }; 
            
            isPositive = false;
        }
    }
}