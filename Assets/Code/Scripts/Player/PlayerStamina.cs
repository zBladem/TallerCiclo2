using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    PlayerMovement movement;
    [SerializeField] float punishSpeed = 2;
    [SerializeField] float maxStamina = 100;
    public float currentStamina;
    [SerializeField] float staminaRegenMultiplier = 3;
    [SerializeField] float staminaConsumptionMultiplier = 4;
    [SerializeField] float punishRegen = 1.5f;
    private bool fatigued;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        currentStamina = maxStamina;
    }
    private void Update()
    {
        StaminaSystem();
    }
    private void StaminaSystem()
    {
        if (movement.Running && !fatigued && currentStamina <= maxStamina && currentStamina != 0)
        {
            currentStamina -= Time.deltaTime * staminaConsumptionMultiplier;

            if (currentStamina <= 0)
            {
                currentStamina = 0;
                fatigued = true;               
            }
        }
        else if (!movement.Running && !fatigued && currentStamina != maxStamina && currentStamina > 0)
        {
            currentStamina += Time.deltaTime * staminaRegenMultiplier;
            if (currentStamina >= maxStamina)
            {
                currentStamina = maxStamina;
            }
        }

        if (fatigued)
        {
            currentStamina += Time.deltaTime * punishRegen;
            movement.Speed = punishSpeed;

            if (currentStamina >= maxStamina)
            {
                fatigued = false;
                currentStamina = maxStamina;
            }

        }
    }

    public bool Fatigued { get { return fatigued; } }
    public float Slowness { get { return punishSpeed; } }
}
