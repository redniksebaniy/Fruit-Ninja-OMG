using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.BlockHalf.HalvesProvider;
using UnityEngine;

namespace App.Scripts.Game.Blocks.BlockBox
{
    public class BlockBox : Block
    {
        [SerializeField] private HalvesProvider halvesProvider;
        
        public override void Init()
        {
            OnChop += (x) =>
            {
                halvesProvider.Create(x);
            };
        }
    }
}