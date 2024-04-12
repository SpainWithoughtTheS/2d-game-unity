using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float damping = 5f; // Adjust this value to control the smoothness of the camera follow
    public float yOffset = 1f;
    public Transform target;

    private Vector3 offset;

    void Start()
    {
        if (target != null)
        {
            offset = transform.position - target.position;
        }
        else
        {
            Debug.LogError("CameraFollow: Target is not assigned!");
        }
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, damping * Time.fixedDeltaTime);
            transform.position = smoothedPosition;
        }
    }
}
