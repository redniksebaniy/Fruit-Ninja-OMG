using App.Scripts.Architecture.MonoInitializable;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Score.SpriteLoader
{
    public class RandomSpriteLoader : MonoInitializable
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        [SerializeField] private Sprite[] sprites;
        
        public override void Init()
        {
            LoadSprite();
        }

        private void LoadSprite()
        {
            int randomID = Random.Range(0, sprites.Length);

            spriteRenderer.sprite = sprites[randomID];
        }
    }
    
    
}