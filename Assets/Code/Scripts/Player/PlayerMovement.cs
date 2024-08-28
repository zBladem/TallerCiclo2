using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [Header("Directional Movement")]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    private float speed;
    private Vector2 moveInput;
    private bool running;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        running = rb.velocity != Vector2.zero && Input.GetKey(KeyCode.LeftShift);

        moveInput.Normalize();

        rb.velocity = moveInput * speed;

        if (moveInput != Vector2.zero && !running)
        {
            speed = walkSpeed;
        }
        else if (moveInput != Vector2.zero && running)
        {
            speed = runSpeed;
        }

    }
}
