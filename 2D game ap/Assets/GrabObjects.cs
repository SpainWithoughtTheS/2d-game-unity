using UnityEngine;

public class CharacterGrab : MonoBehaviour
{
    public KeyCode grabKey = KeyCode.G; // Key to grab objects
    public float grabRange = 1.5f; // Maximum distance to grab objects
    public LayerMask grabbableLayer; // Layer mask for objects that can be grabbed

    private Transform heldObject; // Reference to the object being held (if any)
    private Rigidbody2D characterRigidbody; // Reference to the player's Rigidbody2D component

    void Start()
    {
        // Get the player's Rigidbody2D component
        characterRigidbody = GetComponent<Rigidbody2D>();

        // Freeze rotation along the Z-axis
        characterRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

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
                // Make the object kinematic to prevent it from being affected by physics
                objectRigidbody.isKinematic = true;

                // Set the held object reference
                heldObject = collider.transform;

                // Attach the held object to the character's position
                heldObject.parent = transform;

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

            // Make the released object non-kinematic again to enable physics interactions
            Rigidbody2D objectRigidbody = heldObject.GetComponent<Rigidbody2D>();
            if (objectRigidbody != null)
            {
                objectRigidbody.isKinematic = false;
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
