using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Camera")] 
    public Camera cameraTransform;
   
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float rotationSpeed = 10f;

    [Header("Jump Settings")]
    public float gravity = -9.81f;
    public float jumpHeight = 1.2f;
    public bool canDoubleJump = true;

    [Header("Ground Check")]
    public float groundCheckDistance = 0.2f;
    public LayerMask groundMask;

    private CharacterController _characterController;
    private Vector3 _velocity;
    private bool _isGrounded;
    private bool _hasDoubleJumped;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
        HandleGravityAndJump();
    }

    private void HandleMovement()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var direction = new Vector3(h, 0f, v).normalized;

        if (direction.magnitude >= 0.1f)
        {
            var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.transform.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _characterController.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }
    }

    private void HandleGravityAndJump()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, _characterController.height / 2 + groundCheckDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
            _hasDoubleJumped = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (_isGrounded)
            {
                Jump();
            }
            else if (canDoubleJump && !_hasDoubleJumped)
            {
                Jump();
                _hasDoubleJumped = true;
            }
        }

        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void Jump()
    {
        _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        if (_characterController != null)
        {
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * (_characterController.height / 2 + groundCheckDistance));
        }
    }
}
