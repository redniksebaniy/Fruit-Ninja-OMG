using System.Collections.Generic;
using App.Scripts.Architecture.MonoInitializable;
using App.Scripts.Game.Features.ForcePointProvider.Scriptable;
using App.Scripts.Game.Spawning.BlockProvider;
using UnityEngine;

namespace App.Scripts.Game.Features.ForcePointProvider
{
    public class ForcePointProvider : MonoInitializable
    {
        [SerializeField] private BlockProvider blockProvider;

        [SerializeField] private ForcePointScriptable forceScriptable;

        private class PointInfo
        {
            public readonly Vector3 Position;
            public float Duration;
            
            public PointInfo(float duration, Vector3 position)
            {
                Duration = duration;
                Position = position;
            }
        }
        
        private List<PointInfo> _points;
        
        public override void Init()
        {
            _points = new();
        }

        private void Update()
        {
            if (_points == null) return;
            
            for (int i = 0; i < _points.Count; i++)
            {
                AffectBlocks(_points[i].Position);
                _points[i].Duration += Time.deltaTime;

                if (_points[i].Duration > forceScriptable.forceDuration)
                {
                    _points.RemoveAt(i);
                }
            }
        }

        public void CreateForcePoint(Vector3 position)
        {
            _points.Add(new(0, position));
        }

        private void AffectBlocks(Vector3 position)
        {
            var affectedBlocks = blockProvider.SpawnedBlocks.FindAll(block => 
                Vector3.Distance(position, block.transform.position) < forceScriptable.affectRadius &&
                (block.IsPositive || !forceScriptable.affectOnlyPositive));

            foreach (var affectedBlock in affectedBlocks)
            {
                Vector3 delta = affectedBlock.transform.position - position;
                float angle = Vector2.SignedAngle(Vector2.right, delta);
                float strength = forceScriptable.affectRadius / Mathf.Max(delta.sqrMagnitude, 1f);
                
                affectedBlock.AddForce(angle, strength * forceScriptable.strengthMultiplier);
            }
        }
    }
}