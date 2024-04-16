using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float movSpeed = 5f;
    public float sprintSpeedMultiplier = 2f;
    public float sprintDuration = 3f; // Duration of sprint in seconds
    public float sprintCooldown = 5f; // Cooldown period for sprinting in seconds
    public KeyCode sprintKey = KeyCode.LeftShift;
    public Animator animator;
    public Image sprintBarFill; // Reference to the UI image representing sprint bar
    public AudioClip walkingSound; // Assign the walking sound effect in the Unity Editor

    private Rigidbody2D rb;
    private float sprintBarValue = 1f; // Current value of the sprint bar (0 to 1)
    private bool isSprinting = false;
    private float sprintTimer = 0f;
    private float sprintCooldownTimer = 0f;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateSprintBarUI();

        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is missing, add one
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Set the walking sound effect AudioClip
        audioSource.clip = walkingSound;
    }

 void Update()
{
    HandleSprinting();
    UpdateSprintBarUI();

    float horizontalInput = Input.GetAxisRaw("Horizontal");
    float verticalInput = Input.GetAxisRaw("Vertical");

    // Normalize the movement vector
    Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

    // Set movement based on input
    rb.velocity = movement * movSpeed;

    // Set animator parameters
    if (animator != null)
    {
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Speed", movement.magnitude); // Using magnitude instead of sqrMagnitude
    }

    // Play walking sound effect when the player moves
    if (movement != Vector2.zero && !audioSource.isPlaying)
    {
        audioSource.Play();
    }
    // Stop playing walking sound effect when the player stops moving
    else if (movement == Vector2.zero && audioSource.isPlaying)
    {
        audioSource.Stop();
    }
}


    void HandleSprinting()
    {
        if (Input.GetKeyDown(sprintKey) && sprintBarValue > 0 && sprintCooldownTimer <= 0)
        {
            isSprinting = true;
            sprintTimer = sprintDuration;
        }

        if (isSprinting)
        {
            sprintTimer -= Time.deltaTime;
            if (sprintTimer <= 0)
            {
                isSprinting = false;
                sprintCooldownTimer = sprintCooldown;
            }
        }
        else if (sprintCooldownTimer > 0)
        {
            sprintCooldownTimer -= Time.deltaTime;
        }

        if (sprintCooldownTimer <= 0)
        {
            sprintBarValue = Mathf.Min(sprintBarValue + Time.deltaTime / sprintCooldown, 1f);
        }
        else
        {
            sprintBarValue = Mathf.Max(sprintBarValue - Time.deltaTime / sprintDuration, 0f);
        }
    }

    void UpdateSprintBarUI()
    {
        if (sprintBarFill != null)
        {
            sprintBarFill.fillAmount = sprintBarValue;
        }
    }
}
