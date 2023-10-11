using App.Scripts.Game.Blocks.Shared.Abstract;
using App.Scripts.Game.Blocks.Shared.BlockHalf.HalvesProvider;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Score
{
    public class ScoreBlock : Block
    {
        [SerializeField] private HalvesProvider halvesProvider;
        
        public override void Init()
        {
            
        }

        public override void Chop()
        {
            halvesProvider.Init();
            Destroy(gameObject);
        }
    }
}