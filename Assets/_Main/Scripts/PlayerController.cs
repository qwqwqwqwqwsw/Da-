using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;

    private Rigidbody _rb;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called at a fixed interval and is independent of frame rate
    private void FixedUpdate()
    {
        // Get input from the vertical axis (W/S or Up/Down arrows)
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + movement);
        
        // Get input from the horizontal axis (A/D or Left/Right arrows)
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        _rb.MoveRotation(_rb.rotation * turnRotation);
    }
}
