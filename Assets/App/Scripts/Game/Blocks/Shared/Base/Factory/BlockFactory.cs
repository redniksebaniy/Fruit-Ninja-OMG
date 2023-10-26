using App.Scripts.Architecture.Factory;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.Base.Base
{
    public abstract class BlockFactory : MonoBehaviour, IFactory<Block>
    {
        [SerializeField] protected Block prefab;
        
        public abstract Block Create();
    }
}