using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Blocks.Shared.BlockHalf.HalvesProvider;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Samurai
{
    public class SamuraiBlock : Block
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