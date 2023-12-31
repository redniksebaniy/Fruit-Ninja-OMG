﻿using App.Scripts.Game.Blocks.Shared.Base.MovableObject;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.BlockHalf
{
    public class BlockHalf : MovableObject
    {
        [SerializeField] private SpriteRenderer originalRenderer;
        
        [SerializeField] private SpriteRenderer halfRenderer;

        public bool createSprite;
        public bool isTopHalf;

        public override void Init()
        {
            transform.rotation = originalRenderer.transform.rotation;
            
            if (createSprite) SetSprite();
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