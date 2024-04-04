using UnityEngine;

public class PlayerRotationLock : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();

        // Lock rotation along the Z-axis to keep the player upright in 2D mode
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
