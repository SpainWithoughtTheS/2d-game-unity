using UnityEngine;

public class PlayerSprite3D : MonoBehaviour
{
    public float rotationAmount = 10f; // Amount of rotation in degrees

    void Update()
    {
        // Check if the "E" key is pressed to initiate the rotation
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Rotate the player sprite on the Z-axis by the specified amount
            transform.Rotate(0f, rotationAmount, 0f);
        }

        // Check if the "Q" key is pressed to reset the rotation
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Reset the player sprite's rotation to its original rotation
            transform.rotation = Quaternion.identity;
        }
    }
}
