using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.BlockHalf.HalvesProvider
{
    public class HalvesProvider : MonoBehaviour
    {
        [SerializeField] private BlockHalf[] halves;

        [SerializeField] [Range(0, 90)]
        private float angleMaxOffset;

        [SerializeField] [Min(0)] private float strengthMultiplier;
        
        [SerializeField] [Min(0)] private float minStrength;
        [SerializeField] [Min(0)] private float maxStrength;
        
        public void Create(Vector2 direction)
        {
            var angle = Vector2.SignedAngle(Vector2.right, direction);
            var strength = Mathf.Clamp(direction.magnitude, minStrength, maxStrength);

            float angleOffset = angleMaxOffset;
            if (Mathf.Abs(angle) > 90) angleOffset *= -1; 
            
            foreach (var half in halves)
            {
                var offset = Mathf.Lerp(0, angleOffset, Random.value); 
                half.transform.SetParent(transform.parent);
                half.gameObject.SetActive(true);
                half.SetForce(angle + offset * (half.isTopHalf ? 1 : -1), strength * strengthMultiplier);
            }
        }
    }
}