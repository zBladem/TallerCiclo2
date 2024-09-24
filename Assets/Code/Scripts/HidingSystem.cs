using UnityEngine;

public class HidingSystem : MonoBehaviour
{
    [Header("Hide system")]    
    [SerializeField] Transform hidePos, unhidePos;
    [SerializeField] KeyCode hideKey = KeyCode.E;

    private bool isHiding = false;
    private InteractSystem interact;
    private Transform playerTransform;

    public bool IsHiding { get { return isHiding; } }

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        interact = playerTransform.GetComponent<InteractSystem>();
    }

    void Update()
    {
        if (interact.CanInteract && Input.GetKeyDown(hideKey) && !isHiding) Hide();
        else if (isHiding && Input.GetKeyDown(hideKey)) UnHide();
    }
    private void Hide()
    {
        isHiding = true;
        playerTransform.position = hidePos.position;        
        Debug.Log("Is hiding");
    }
    private void UnHide()
    {
        isHiding = false;
        playerTransform.position = unhidePos.position;
        Debug.Log("Isn't hiding");
    }


}
