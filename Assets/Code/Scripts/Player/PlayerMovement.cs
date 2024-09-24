using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerStamina stamina;
    private HidingSystem hidingSystem;
    [Header("Movement")]
    [SerializeField] float walkSpeed = 5;
    [SerializeField] float runSpeed = 7;
    [SerializeField] float tiredSpeed = 3.5f;
    bool running;
    float currentSpeed;
    Vector2 moveInput;
    public bool Running { get { return running; } }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stamina = GetComponent<PlayerStamina>();
        hidingSystem = GetComponent<HidingSystem>();
    }
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        running = moveInput != Vector2.zero && Input.GetKey(KeyCode.LeftShift);

        rb.velocity = moveInput * currentSpeed;

        if (!running && !stamina.Tired && !hidingSystem.IsHiding) currentSpeed = walkSpeed;

        else if (running && !stamina.Tired && !hidingSystem.IsHiding) currentSpeed = runSpeed;

        else if (hidingSystem.IsHiding) currentSpeed = 0;

        else if (stamina.Tired) currentSpeed = tiredSpeed;
    }
}
