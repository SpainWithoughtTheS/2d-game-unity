using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public GameObject bulletPrefab; // Prefab of the homing bullet
    public GameObject meleeWeapon; // Reference to the melee weapon object
    public float bulletSpeed = 5f; // Speed of the homing bullet
    public float meleeRange = 2f; // Range of the melee attack
    public float fireRate = 2f; // Rate of fire in bullets per second

    private float bulletLifetime = 2f; // Lifetime of the homing bullet
    private float fireTimer; // Timer to track when to fire next
    private bool usingRanged = true; // Flag to track if the boss is using ranged attack
// Reference to the player's transform
    public float moveSpeed = 2f; // Boss movement speed

    private Rigidbody2D rb;
    private Vector2 movementDirection;
     
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Rotate towards the player
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Check if the player is within melee range
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= meleeRange)
        {
            if (usingRanged)
            {
                SwitchToMelee();
            }
            else
            {
                // Perform melee attack
                MeleeAttack();
            }
        }
        else
        {
            if (!usingRanged)
            {
                SwitchToRanged();
            }

            // Fire bullets at regular intervals
            fireTimer += Time.deltaTime;
            if (fireTimer >= 1f / fireRate)
            {
                FireBullet();
                fireTimer = 0f;
            }
        }
        
        
         movementDirection = (player.position - transform.position).normalized;
    }

      void FixedUpdate()
    {
        // Move towards the player
        rb.MovePosition(rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void FireBullet()
    {
        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        
        // Set the velocity of the bullet towards the player
        Vector2 direction = (player.position - transform.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        // Destroy the bullet after its lifetime expires
        Destroy(bullet, bulletLifetime);
    }

    void SwitchToMelee()
    {
        // Disable the ranged weapon and enable the melee weapon
        bulletPrefab.SetActive(false);
        meleeWeapon.SetActive(true);

        usingRanged = false;
    }

    void SwitchToRanged()
    {
        // Enable the ranged weapon and disable the melee weapon
        bulletPrefab.SetActive(true);
        meleeWeapon.SetActive(false);

        usingRanged = true;
    }

    void MeleeAttack()
    {
        // Perform the melee attack (e.g., deal damage to the player)
        // You can add your melee attack logic here
        Debug.Log("Boss performs melee attack!");
    }
}
