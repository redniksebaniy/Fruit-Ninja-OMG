using UnityEngine;

namespace App.Scripts.Game.Features.ForcePointProvider.Magnet
{
    public class MagnetForcePointProvider : Base.ForcePointProvider
    {
        public override void AffectBlocks(Vector3 position)
        {
            var affectedBlocks = FindBlocksNearby(position);
            
            foreach (var affectedBlock in affectedBlocks)
            {
                Vector3 delta = affectedBlock.transform.position - position;
                float angle = Vector2.SignedAngle(Vector2.right, delta);
                float strength = delta.magnitude;

                if (strength < forceScriptable.middleAffectRadius) angle += 180;
                
                strength *= -forceScriptable.strengthMultiplier * Time.deltaTime;
                affectedBlock.AddForce(angle, strength);
            }
        }
    }
}