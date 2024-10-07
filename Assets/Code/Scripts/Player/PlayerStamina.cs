using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    PlayerMovement movement;

    [Header("Stamina")]
    [SerializeField] float maxStamina = 50;
    [SerializeField] float staminaRegen = 5;
    [SerializeField] float staminaComsuption = 3;
    [SerializeField] float staminaPunishRegen = 4;
    float currentStamina;
    private bool tired;

    #region public values
    public bool Tired { get { return tired; } }
    public float MaxStamina { get { return maxStamina; } set { maxStamina = value; } }
    public float StaminaRegen { get { return staminaRegen; } set { staminaRegen = value; } }
    public float StaminaComsuption { get { return staminaComsuption; } set { staminaComsuption = value; } }
    public float StaminaPunishRegen { get { return StaminaPunishRegen; } set { StaminaPunishRegen = value; } }
    #endregion
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
            currentStamina += Time.deltaTime * StaminaPunishRegen;

            if (currentStamina >= maxStamina)
            {
                tired = false;
                currentStamina = maxStamina;                
            }
        }
    }
}
