using UnityEngine;

public class SimpleBlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Block block;

    [SerializeField]
    private float spawnDeltaTime;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBlock), 1, spawnDeltaTime);
    }

    private void SpawnBlock()
    {
        Block newBlock = Instantiate(block, transform.position, Quaternion.identity);

        Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(-90, 90));
        newBlock.SetForce(rotation * Vector2.up * Random.Range(5, 10));
    }
}
