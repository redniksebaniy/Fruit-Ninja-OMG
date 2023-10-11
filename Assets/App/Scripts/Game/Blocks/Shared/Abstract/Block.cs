using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Abstract
{
    public abstract class Block : MovableObject.MovableObject, IChopable
    {
        [SerializeField] [Min(0)] private float size = 1f;
        
        public float Size
        {
            get
            {
                return size * transform.lossyScale.z;
            }
            private set
            {
                size = value;
            }
        }
        
        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        public abstract void Chop();
    }
}
