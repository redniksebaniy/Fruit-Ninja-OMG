using UnityEngine;

public abstract class Block : MonoBehaviour, ICuttable
{
    [SerializeField]
    float gravityCoefficient = 9.81f;

    private Vector3 currentVelocity;

    private void FixedUpdate()
    {
        currentVelocity.y -= gravityCoefficient * Time.fixedDeltaTime / 2;

        transform.position += currentVelocity * Time.fixedDeltaTime;
    }

    public void SetForce(float angle, float strength = 1f)
    {
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right;
        currentVelocity = direction * strength;
    }

    public abstract void Cut();
}
