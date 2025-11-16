using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject effectPrefab;
    
    private void OnTriggerEnter(Collider other)
    {
        // Destroy the collectible and instantiate an effect when the player collides with it
        if (other.CompareTag("Player"))
        {
            Instantiate(effectPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}