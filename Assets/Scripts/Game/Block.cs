using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField]
    float gravityCoefficient = 9.81f;

    private Vector3 currentVelocity;

    private void FixedUpdate()
    {
        currentVelocity.y -= gravityCoefficient * Time.fixedDeltaTime / 2;

        transform.position += currentVelocity * Time.fixedDeltaTime;
    }

    public void SetForce(Vector3 velocity)
    {
        currentVelocity = velocity;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
