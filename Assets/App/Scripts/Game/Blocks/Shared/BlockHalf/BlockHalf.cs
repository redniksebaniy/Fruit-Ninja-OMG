using App.Scripts.Game.Blocks.Shared.Abstract.MovableObject;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.BlockHalf
{
    public class BlockHalf : MovableObject
    {
        [SerializeField] private SpriteRenderer originalRenderer;
        
        [SerializeField] private SpriteRenderer halfRenderer;

        [SerializeField] private bool isTopHalf;

        [SerializeField] [Range(-180, 180)] private int minAngle;
        [SerializeField] [Range(-180, 180)] private int maxAngle;

        [SerializeField] [Min(0)] private int minStrength;
        [SerializeField] [Min(0)] private int maxStrength;
        
        public override void Init()
        {
            transform.rotation = originalRenderer.transform.rotation;
            SetSprite();
            SetRandomForce();
        }

        private void SetSprite()
        {
            var sprite = originalRenderer.sprite;

            Rect halfRect = sprite.rect;
            halfRect.height /= 2;
            if (isTopHalf) halfRect.y = halfRect.height;
            
            halfRenderer.sprite = Sprite.Create(sprite.texture, halfRect, Vector2.zero);
        }
        
        private void SetRandomForce()
        {
            float angle = Mathf.Lerp(minAngle, maxAngle, Random.value);
            float strength = Mathf.Lerp(minStrength, maxStrength, Random.value);
            
            SetForce(angle, strength);
        }
    }
}