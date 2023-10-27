using UnityEngine;

namespace App.Scripts.Game.Features.ForcePointProvider.Bomb
{
    public class BombForcePointProvider: Base.ForcePointProvider
    {
        public override void AffectBlocks(Vector3 position)
        {
            var affectedBlocks = FindBlocksNearby(position);

            foreach (var affectedBlock in affectedBlocks)
            {
                Vector3 delta = affectedBlock.transform.position - position;
                float angle = Vector2.SignedAngle(Vector2.right, delta);
                float strength = forceScriptable.strengthMultiplier / delta.magnitude;
                
                affectedBlock.AddForce(angle, strength);
            }
        }
    }
}