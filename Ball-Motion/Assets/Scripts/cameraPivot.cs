using UnityEngine;

public class BirdseyeCameraFollow : MonoBehaviour
{
    public Transform target;       // Your ball
    public Vector3 offset = new Vector3(0f, 8f, 0f);
    public float smoothSpeed = 5f;

    private Vector3 currentVelocity;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, 1f / smoothSpeed);

        // Look straight down
        transform.rotation = Quaternion.Euler(90f, 0f, 0f);
    }
}


