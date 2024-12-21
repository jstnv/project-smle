using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CharacterStats characterStats; // Reference to the CharacterStats (assigned in Inspector)
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("XPItem"))
        {
            // Pick up the item and grant XP
            int xpGained = Random.Range(10, 51); // Random XP between 10 and 50
            characterStats.AddXP("strength", xpGained);  // Increase "strength" stat (or any stat you choose)
            Debug.Log($"Gained {xpGained} XP for strength!");
            
            // Destroy the item after pickup
            Destroy(other.gameObject);
        }
    }
}
