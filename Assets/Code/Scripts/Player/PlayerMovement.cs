using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerStamina stamina;
    private Transform hideInteract;
    private Animator animator;
    private HidingSystem hidingSystem;

    [Header("Movement")]
    [SerializeField] float walkSpeed = 5;
    [SerializeField] float runSpeed = 7;
    [SerializeField] float tiredSpeed = 3.5f;
    bool running;
    float currentSpeed;
    Vector2 moveInput;
    #region Public values
    public Vector2 MoveInput { get { return moveInput; } }
    public bool Running { get { return running; } }
    public float WalkSpeed { get { return walkSpeed; } set { walkSpeed = value; } }
    public float RunSpeed { get { return runSpeed; } set { runSpeed = value; } }
    public float TiredSpeed { get {return tiredSpeed; } set { tiredSpeed = value; } }
    #endregion
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stamina = GetComponent<PlayerStamina>();
    }
    private void Start()
    {
        hideInteract = GameObject.FindGameObjectWithTag("HideInteract").transform;
        hidingSystem = hideInteract.GetComponent<HidingSystem>();        
    }
    void Update()
    {
        Movement();
        PlayerAnimations();
    }
    private void Movement()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal"); moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        running = moveInput != Vector2.zero && Input.GetKey(KeyCode.LeftShift) && !stamina.Tired;

        rb.velocity = moveInput * currentSpeed;

        if (!running && !stamina.Tired && !hidingSystem.IsHiding) currentSpeed = walkSpeed;

        else if (running && !stamina.Tired && !hidingSystem.IsHiding) currentSpeed = runSpeed;

        else if (hidingSystem.IsHiding) currentSpeed = 0;

        else if (stamina.Tired) currentSpeed = tiredSpeed;
    }
    private void PlayerAnimations()
    {
        animator.SetBool("Running", running);
        animator.SetBool("Tired", stamina.Tired);

        if (!hidingSystem.IsHiding)
        {
            animator.SetFloat("Xaxis", moveInput.x); animator.SetFloat("Yaxis", moveInput.y);

            if (moveInput != Vector2.zero)
            {
                animator.SetFloat("DirX", moveInput.x); animator.SetFloat("DirY", moveInput.y);
            }
        }
    }
}
