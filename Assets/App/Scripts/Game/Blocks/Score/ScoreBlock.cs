using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.BlockHalf.HalvesProvider;
using App.Scripts.Game.Blocks.Shared.ParticleProvider;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Score
{
    public class ScoreBlock : Block
    {
        [SerializeField] private HalvesProvider halvesProvider;
        
        [SerializeField] private ParticleProvider particleProvider;
        
        public override void Init()
        {
            particleProvider.Init();

            OnChop += (x) =>
            {
                halvesProvider.Create(x);
                particleProvider.PlayParticles();
            }; 
        }
    }
}