using UnityEngine;

namespace App.Scripts.Game.Features.ForcePointProvider.Base
{
    public interface IBlockForceProvider
    {
        public void AffectBlocks(Vector3 position);
    }
}