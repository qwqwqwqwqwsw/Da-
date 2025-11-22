using UnityEngine;

public class Collectible2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController2D>() != null)
        {
            Destroy(gameObject);
            var collectibleCounter = FindObjectOfType<CollectibleCounter>();
            
            collectibleCounter.IncrementCounter();
        }
    }
}