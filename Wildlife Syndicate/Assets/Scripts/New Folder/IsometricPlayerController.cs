using UnityEngine;

public class IsometricPlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed
    private Vector2 movement; // Stores the player's movement input

    private Rigidbody2D rb; // Rigidbody2D for physics-based movement

    public CharacterStats characterStats; // Reference to stats system

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get player input
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow
        movement.y = Input.GetAxisRaw("Vertical"); // W/S or Up/Down Arrow

        // Normalize movement for isometric speed consistency
        movement = movement.normalized;
    }

    private void FixedUpdate()
    {
        // Apply movement
        rb.velocity = new Vector2(movement.x + movement.y, (movement.y - movement.x)) * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("XPItem"))
        {
            // Grant XP on item pickup
            int xpGained = Random.Range(10, 51); // Random XP between 10 and 50
            characterStats.AddXP("strength", xpGained); // Add XP to a stat
            Debug.Log($"Gained {xpGained} XP for strength!");

            // Destroy the XP item
            Destroy(other.gameObject);
        }
    }
}
