using App.Scripts.Game.Blocks.Factories.Base;
using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Input.SwipeInputObserver;
using UnityEngine;
using Cursor = App.Scripts.Input.Cursor.Cursor;

namespace App.Scripts.Game.Blocks.Factories.BrickBlockFactory
{
    public class BrickBlockFactory : BlockFactory
    {
        [Header("Chopper Components")] [SerializeField]
        private SwipeInputObserver observer;
        
        [SerializeField]
        private Cursor cursor;

        public override Block Create()
        {
            var newPrefab = Instantiate(prefab, transform);
            
            newPrefab.OnChop += (x) =>
            {
                cursor.SetCursorState(false);
                observer.ResetSwipeInfo();
            };
            
            return newPrefab;
        }
    }
}