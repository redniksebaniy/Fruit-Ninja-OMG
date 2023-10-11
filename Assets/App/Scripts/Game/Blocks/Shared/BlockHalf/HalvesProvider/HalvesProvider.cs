using App.Scripts.Architecture.MonoInitializable;
using UnityEngine;

namespace App.Scripts.Game.Blocks.Shared.BlockHalf.HalvesProvider
{
    public class HalvesProvider : MonoInitializable
    {
        [SerializeField] private BlockHalf[] halves;

        public override void Init()
        {
            foreach (var half in halves)
            {
                half.transform.parent = transform.parent;
                half.gameObject.SetActive(true);
            }
        }
    }
}