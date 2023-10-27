using System.Collections.Generic;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Blocks.Shared.Base;
using App.Scripts.Game.Features.ForcePointProvider.Base.Scriptable;
using App.Scripts.Game.Spawning.BlockProvider;
using UnityEngine;

namespace App.Scripts.Game.Features.ForcePointProvider.Base
{
    public abstract class ForcePointProvider : MonoInitializable, IBlockForceProvider
    {
        [SerializeField] protected BlockProvider blockProvider;

        [SerializeField] protected ForcePointScriptable forceScriptable;

        protected class PointInfo
        {
            public readonly Vector3 Position;
            public float Duration;
            
            public PointInfo(float duration, Vector3 position)
            {
                Duration = duration;
                Position = position;
            }
        }
        
        protected List<PointInfo> Points;
        
        public override void Init()
        {
            Points = new();
        }

        private void Update()
        {
            if (Points == null) return;
            
            for (int i = 0; i < Points.Count; i++)
            {
                AffectBlocks(Points[i].Position);
                Points[i].Duration += Time.deltaTime;

                if (Points[i].Duration > forceScriptable.forceDuration)
                {
                    Points.RemoveAt(i);
                }
            }
        }

        public void CreateForcePoint(Vector3 position)
        {
            Points.Add(new(0, position));
        }

        protected List<Block> FindBlocksNearby(Vector3 position)
        {
            return blockProvider.SpawnedBlocks.FindAll(block => 
                Vector3.Distance(position, block.transform.position) < forceScriptable.affectRadius &&
                (block.IsPositive || !forceScriptable.affectOnlyPositive));
        }
        
        public abstract void AffectBlocks(Vector3 position);
    }
}