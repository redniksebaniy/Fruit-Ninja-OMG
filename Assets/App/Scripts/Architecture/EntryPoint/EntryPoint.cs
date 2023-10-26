using UnityEngine;

namespace App.Scripts.Architecture.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private MonoInitializable.MonoInitializable[] monoInitializables;
        
        public void Awake()
        {
            foreach (var monoInitializable in  monoInitializables)
            {
                monoInitializable.Init();
            }
        }
    }
}
