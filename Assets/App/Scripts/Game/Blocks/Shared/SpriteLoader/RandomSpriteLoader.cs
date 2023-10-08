using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.SpriteLoader
{
    public class RandomSpriteLoader : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        [SerializeField] private string path;
        
        private void Start()
        {
            LoadSprite();
        }

        private void LoadSprite()
        {
            var sprites = Resources.LoadAll<Sprite>(path);

            int randomID = Random.Range(0, sprites.Length);
            spriteRenderer.sprite = sprites[randomID];
        }
    }
    
    
}