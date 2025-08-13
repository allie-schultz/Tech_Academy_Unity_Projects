using UnityEngine;

public class CrowMovement : MonoBehaviour
{
    public float verticalSpeed = 5f;
    public float minY = -4f;
    public float maxY = 4f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveY = Input.GetAxisRaw("Vertical") * verticalSpeed;

        rb.linearVelocity = new Vector2(0, moveY);

        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}


