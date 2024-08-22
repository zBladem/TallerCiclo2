using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float walkSpeed;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Moving();
    }
    public void Moving()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * walkSpeed;

    }
}
