using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
        transform.position += Vector3.up * 0.2f * Mathf.Sin(Time.time * 2f) * Time.deltaTime;
    }
}