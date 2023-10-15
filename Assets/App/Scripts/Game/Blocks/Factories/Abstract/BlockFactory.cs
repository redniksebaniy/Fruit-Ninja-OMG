using System;
using App.Scripts.Architecture.Factory;
using App.Scripts.Game.Blocks.Shared.Abstract;
using UnityEngine;
using UnityEngine.Events;

namespace App.Scripts.Game.Blocks.Factories.Abstract
{
    public abstract class BlockFactory : MonoBehaviour, IFactory<Block>
    {
        [SerializeField] protected UnityEvent OnBlockChop;
        
        [SerializeField] protected UnityEvent OnBlockMiss;
        
        public abstract Block Create();

        private void OnDestroy()
        {
            OnBlockChop.RemoveAllListeners();
            OnBlockMiss.RemoveAllListeners();
        }
    }
}