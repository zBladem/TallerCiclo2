using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
     PlayerStamina stamina;
    [Header("Directional Movement")]
    [SerializeField] float walkSpeed = 5;
    [SerializeField] float runSpeed = 8;
    private float speed;
    private Vector2 moveInput;
    private bool running;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stamina = GetComponent<PlayerStamina>();
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

        if (!running && !stamina.Fatigued)
        {
            speed = walkSpeed;
        }
        else if (running && !stamina.Fatigued)
        {
            speed = runSpeed;
        }      

    }
    #region public values
    public float Speed {get {return speed;} set { speed = value;} }
    public bool Running { get { return running; } }
    #endregion
}
