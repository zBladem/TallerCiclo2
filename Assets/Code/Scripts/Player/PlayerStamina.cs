using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    PlayerMovement movement;

    [Header("Stamina")]
    [SerializeField] float maxStamina = 50;
    [SerializeField] float staminaRegen = 5;
    [SerializeField] float staminaComsuption = 3;
    [SerializeField] float staminaTiredRegen = 4;
    float currentStamina;
    private bool tired;
    public bool Tired { get { return tired; } }
    void Awake()
    {
        currentStamina = maxStamina;
        movement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        StaminaSystem();        
    }
    private void StaminaSystem()
    {
        if (movement.Running && currentStamina != 0 && currentStamina <= maxStamina && !tired)
        {
            currentStamina -= Time.deltaTime * staminaComsuption;

            if (currentStamina <= 0)
            {
                tired = true;
                currentStamina = 0;
            }
        }
        else if (!movement.Running && currentStamina > 0 && currentStamina != maxStamina && !tired)
        {
            currentStamina += Time.deltaTime * staminaRegen;

            if (currentStamina >= maxStamina) currentStamina = maxStamina;
        }

        if (tired)
        {
            currentStamina += Time.deltaTime * staminaTiredRegen;

            if (currentStamina >= maxStamina)
            {
                tired = false;
                currentStamina = maxStamina;                
            }
        }
    }
}
