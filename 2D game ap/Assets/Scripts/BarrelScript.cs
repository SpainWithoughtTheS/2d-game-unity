using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Set the properties
        rb.mass = 0f; // Set mass to 0
        rb.drag = Mathf.Infinity; // Set max linear drag
        rb.angularDrag = Mathf.Infinity; // Set max angular drag
        rb.gravityScale = 0f; // Disable gravity
        rb.isKinematic = true; // Set kinematic to true
    }

    void OnMouseDown()
    {
        // Check if the object is not already grabbed
        if (!rb.isKinematic)
        {
            // Grab the object
            Grab();
        }
    }

    void Grab()
    {
        // Make the object kinematic to allow it to be moved by the player
        rb.isKinematic = true;

        // Parent the object to the player's transform
        transform.parent = Camera.main.transform;
    }

    void Release()
    {
        // Unparent the object from the player's transform
        transform.parent = null;

        // Make the object non-kinematic to resume physics interactions
        rb.isKinematic = false;
    }
}
