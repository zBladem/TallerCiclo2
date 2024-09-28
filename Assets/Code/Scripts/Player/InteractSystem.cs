using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    PlayerMovement movement;
    [Header("Interact")]
    [SerializeField] float HitboxSize = 0.5f;
    [SerializeField] Transform hitbox;
    [SerializeField] LayerMask InteractLayer;
    public bool CanInteract { get { return InteractHitbox(); } }
    private Vector2 lastPlayerDir;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        if (movement.MoveInput != Vector2.zero) lastPlayerDir = movement.MoveInput;
        InteractHitbox();
    }
    private bool InteractHitbox()
    {
        if (Physics2D.OverlapCircle((Vector2)hitbox.position + lastPlayerDir, HitboxSize, InteractLayer)) return true;
        return false;
    }
    private void OnDrawGizmos()
    {
       Gizmos.DrawWireSphere((Vector2)hitbox.position + lastPlayerDir, HitboxSize);
    }
}
