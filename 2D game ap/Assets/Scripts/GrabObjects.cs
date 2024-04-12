using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    public KeyCode grabKey = KeyCode.G; // Key to grab/release objects
    public float grabRange = 1.5f; // Maximum distance to grab objects
    public LayerMask grabbableLayer; // Layer mask for objects that can be grabbed

    private Transform heldObject; // Reference to the object being held (if any)

    void Update()
    {
        // Check if the grab key is pressed
        if (Input.GetKeyDown(grabKey))
        {
            // Check if the character is already holding an object
            if (heldObject != null)
            {
                // Release the held object
                ReleaseObject();
            }
            else
            {
                // Attempt to grab an object
                GrabObject();
            }
        }
    }

    void GrabObject()
    {
        // Perform a circle cast to find grabbable objects within the grab range
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, grabRange, grabbableLayer);

        // Check if any grabbable objects are found
        foreach (Collider2D collider in colliders)
        {
            // Attempt to grab the first found object
            Rigidbody2D objectRigidbody = collider.GetComponent<Rigidbody2D>();
            if (objectRigidbody != null)
            {
                // Set the held object reference
                heldObject = collider.transform;

                // Attach the held object to the character's position
                heldObject.parent = transform;

                // Disable physics interactions with the grabbed object
                objectRigidbody.simulated = false;

                // Exit the loop after grabbing the first object
                break;
            }
        }
    }

    void ReleaseObject()
    {
        // Check if a held object exists
        if (heldObject != null)
        {
            // Release the held object
            heldObject.parent = null;

            // Enable physics interactions with the released object
            Rigidbody2D objectRigidbody = heldObject.GetComponent<Rigidbody2D>();
            if (objectRigidbody != null)
            {
                objectRigidbody.simulated = true;
            }

            heldObject = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a visual representation of the grab range in the Scene view
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}
