using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandConsole : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerMovement playerMovement;

    [Header("UI Elements")]
    public TMP_InputField walkSpeedInput;
    public TMP_InputField runSpeedInput;
    public TMP_InputField tiredSpeedInput;
    public Button applyButton;
    private bool isConsoleVisible = false;
    public GameObject consolePanel;
    void Start()
    {
 
        consolePanel.SetActive(false);

 
        applyButton.onClick.AddListener(ApplyValues);
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isConsoleVisible = !isConsoleVisible;
            consolePanel.SetActive(isConsoleVisible); 
        }
    }

    private void ApplyValues()
    {
        float walkSpeed, runSpeed, tiredSpeed;

        if (!string.IsNullOrEmpty(walkSpeedInput.text) && float.TryParse(walkSpeedInput.text, out walkSpeed))
        {
            playerMovement.WalkSpeed = walkSpeed;
            Debug.Log($"WalkSpeed actualizado a: {playerMovement.WalkSpeed}");
        }

        if (!string.IsNullOrEmpty(runSpeedInput.text) && float.TryParse(runSpeedInput.text, out runSpeed))
        {
            playerMovement.RunSpeed = runSpeed;
            Debug.Log($"RunSpeed actualizado a: {playerMovement.RunSpeed}");
        }

        if (!string.IsNullOrEmpty(tiredSpeedInput.text) && float.TryParse(tiredSpeedInput.text, out tiredSpeed))
        {
            playerMovement.TiredSpeed = tiredSpeed;
            Debug.Log($"TiredSpeed actualizado a: {playerMovement.TiredSpeed}");
        }

        if (string.IsNullOrEmpty(walkSpeedInput.text) &&
            string.IsNullOrEmpty(runSpeedInput.text) &&
            string.IsNullOrEmpty(tiredSpeedInput.text))
        {
            Debug.Log("No se ingresaron valores nuevos.");
        }
    }
}