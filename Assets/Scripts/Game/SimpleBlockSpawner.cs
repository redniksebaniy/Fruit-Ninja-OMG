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

        float randomAngle = Random.Range(0, 180);
        newBlock.SetForce(randomAngle, 5);
    }
}
