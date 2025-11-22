using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 5f;
    public bool canMoveDiagonally = true;

    private Rigidbody2D _rb;
    private Vector2 _movement;
    private bool _isMovingHorizontally;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (canMoveDiagonally)
        {
            _movement = new Vector2(horizontal, vertical);

            RotatePlayer(horizontal, vertical);
        }
        else
        {
            if (horizontal != 0)
            {
                _isMovingHorizontally = true;
            }
            else if (vertical != 0)
            {
                _isMovingHorizontally = false;
            }

            if (_isMovingHorizontally)
            {
                _movement = new Vector2(0, vertical);
                RotatePlayer(horizontal, 0);
            }
            else
            {
                _movement = new Vector2(0, vertical);
                RotatePlayer(0, vertical);
            }
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _movement * speed;
    }


    private void RotatePlayer(float x, float y)
    {
        if (x == 0 && y == 0) return;
        {
            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}