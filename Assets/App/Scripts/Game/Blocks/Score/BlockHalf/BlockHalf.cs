using App.Scripts.Game.Blocks.Shared.Abstract.MovableObject;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Score.BlockHalf
{
    public class BlockHalf : MovableObject
    {
        [SerializeField] private SpriteRenderer originalRenderer;
        
        [SerializeField] private SpriteRenderer halfRenderer;
        
        public bool isTopHalf;

        public override void Init()
        {
            transform.rotation = originalRenderer.transform.rotation;
            
            SetSprite();
        }

        private void SetSprite()
        {
            var sprite = originalRenderer.sprite;

            Rect halfRect = sprite.rect;
            halfRect.height /= 2;
            if (isTopHalf) halfRect.y = halfRect.height;
            
            halfRenderer.sprite = Sprite.Create(sprite.texture, halfRect, Vector2.zero);
        }
        
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }
    }
}