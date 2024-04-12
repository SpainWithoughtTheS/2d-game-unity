using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D m_rigidBody2D;
    public float moveSpeed;
    Vector2 movement;

    void Update()
    {
        // Get horizontal and vertical input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Store input in the movement vector
        movement = new Vector2(horizontalInput, verticalInput);
    }

    private void FixedUpdate()
    {
        // Move the player using Rigidbody2D
        m_rigidBody2D.MovePosition(m_rigidBody2D.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
