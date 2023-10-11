using UnityEngine;

namespace App.Scripts.Game.Blocks.Score.BlockHalf.HalvesProvider
{
    public class HalvesProvider : MonoBehaviour
    {
        [SerializeField] private BlockHalf[] halves;

        public void CreateHalves()
        {
            foreach (var half in halves)
            {
                half.transform.parent = transform.parent;
                half.gameObject.SetActive(true);
            }
        }
    }
}