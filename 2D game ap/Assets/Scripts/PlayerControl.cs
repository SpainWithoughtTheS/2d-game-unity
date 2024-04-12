using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float movSpeed = 5f;
    public float sprintSpeedMultiplier = 2f;
    public float sprintDuration = 3f; // Duration of sprint in seconds
    public float sprintCooldown = 5f; // Cooldown period for sprinting in seconds
    public KeyCode sprintKey = KeyCode.LeftShift;

    public Image sprintBarFill; // Reference to the UI image representing sprint bar

    private Rigidbody2D rb;
    private float sprintBarValue = 1f; // Current value of the sprint bar (0 to 1)
    private bool isSprinting = false;
    private float sprintTimer = 0f;
    private float sprintCooldownTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateSprintBarUI();
    }

    void Update()
    {
        HandleSprinting();
        UpdateSprintBarUI();

        float currentMovSpeed = isSprinting ? movSpeed * sprintSpeedMultiplier : movSpeed;
        float speedX = Input.GetAxisRaw("Horizontal") * currentMovSpeed;
        float speedY = Input.GetAxisRaw("Vertical") * currentMovSpeed;
        rb.velocity = new Vector2(speedX, speedY);
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
