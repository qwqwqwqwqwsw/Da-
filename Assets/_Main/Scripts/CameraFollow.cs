using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    public float sensitivity = 3f;

    private float mouseX, mouseY;

    void LateUpdate()
    {
        if (!target) return;

        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -35f, 60f);

        transform.position = target.position + Quaternion.Euler(mouseY, mouseX, 0) * offset;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}