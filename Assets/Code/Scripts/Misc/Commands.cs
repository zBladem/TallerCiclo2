using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Commands : MonoBehaviour
{
    public GameObject consolePanel;    

    private PlayerMovement playerMovement;
    private PlayerStamina playerStamina;   
    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        playerStamina = FindObjectOfType<PlayerStamina>();

        consolePanel.SetActive(false);    
    }

    private void Update()
    {
        ToggleConsole();
    }
    private void ToggleConsole()
    {        
        if (Input.GetKeyDown(KeyCode.Tab)) consolePanel.SetActive(!consolePanel.activeSelf);        
    }
}