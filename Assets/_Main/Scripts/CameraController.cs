using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float fastSpeed = 30f;

    public float lookSensitivity = 2f;
    private float _rotationX;
    private float _rotationY;

    private void Update()
    {
        HandleLook();
        HandleMove();
    }

    private void HandleMove()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? fastSpeed : moveSpeed;

        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) direction += transform.forward;
        if (Input.GetKey(KeyCode.S)) direction -= transform.forward;
        if (Input.GetKey(KeyCode.A)) direction -= transform.right;
        if (Input.GetKey(KeyCode.D)) direction += transform.right;
        if (Input.GetKey(KeyCode.E)) direction += transform.up;
        if (Input.GetKey(KeyCode.Q)) direction -= transform.up;
        
        transform.position += direction.normalized * speed * Time.deltaTime;
    }

    private void HandleLook()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _rotationX += Input.GetAxis("Mouse X") * lookSensitivity;
            _rotationY -= Input.GetAxis("Mouse Y") * lookSensitivity;
            _rotationY = Mathf.Clamp(_rotationY, -89f, 89f);

            transform.rotation = Quaternion.Euler(_rotationY, _rotationX, 0f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
