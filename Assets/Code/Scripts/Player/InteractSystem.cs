using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    [Header("Interact")]
    [SerializeField] float HitboxSize = 0.5f;
    [SerializeField] Transform hitbox;
    [SerializeField] LayerMask InteractLayer;
    public bool CanInteract { get { return InteractHitbox(); } }
    void Update()
    {
        InteractHitbox();
    }
    private bool InteractHitbox()
    {
        if (Physics2D.OverlapCircle(hitbox.position, HitboxSize, InteractLayer)) return true;
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitbox.position, HitboxSize);
    }
}
