using App.Scripts.Architecture.Factory;
using App.Scripts.Game.Blocks.Shared.Abstract;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Factories.Base
{
    public abstract class BlockFactory : MonoBehaviour, IFactory<Block>
    {
        [SerializeField] protected Block prefab;
        
        public abstract Block Create();
    }
}