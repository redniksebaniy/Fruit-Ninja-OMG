using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Architecture.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private List<MonoInitializable.MonoInitializable> monoInitializables;
        
        private void Start()
        {
            foreach (var monoInitializable in  monoInitializables)
            {
                monoInitializable.Init();
            }
        }
    }
}
