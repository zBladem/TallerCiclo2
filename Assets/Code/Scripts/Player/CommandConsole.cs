using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CommandConsole : MonoBehaviour
{
    Transform player;
    PlayerMovement playerMovement;

    [Header("UI elements")]
    public GameObject consolepanel;
    public TMP_InputField walkspeedinput;
    public TMP_InputField runspeedinput;
    public TMP_InputField tiredspeedinput;
    public Button applybutton;
    public TextMeshProUGUI walkspeedtext;
    public TextMeshProUGUI runspeedtext;   
    public TextMeshProUGUI tiredspeedtext;

    private bool isconsolevisible = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = player.GetComponent<PlayerMovement>();

        consolepanel.SetActive(false);

        applybutton.onClick.AddListener(applyvalues);

        valoresacutales();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isconsolevisible = !isconsolevisible;
            consolepanel.SetActive(isconsolevisible);
            if (isconsolevisible) { valoresacutales(); }
        }
    }
    private void applyvalues()
    {
        float walkspeed, runspeed, tiredspeed;

        if(!string.IsNullOrEmpty(walkspeedinput.text)&&float.TryParse(walkspeedinput.text, out walkspeed))
        {
            playerMovement.WalkSpeed=walkspeed;
            Debug.Log($"walkspeed acutalizado a: {playerMovement.WalkSpeed}");
        }

        if (!string.IsNullOrEmpty(runspeedinput.text) && float.TryParse(runspeedinput.text, out runspeed))
        {
            playerMovement.RunSpeed = runspeed;
            Debug.Log($"runspeed acutalizado a: {playerMovement.RunSpeed}");
        }
        if (!string.IsNullOrEmpty(tiredspeedinput.text) && float.TryParse(tiredspeedinput.text, out tiredspeed))
        {
            playerMovement.TiredSpeed = tiredspeed;
            Debug.Log($"tiredspeed acutalizado a: {playerMovement.TiredSpeed}");
        }

        if(string.IsNullOrWhiteSpace(walkspeedinput.text) &&
            string.IsNullOrWhiteSpace(runspeedinput.text) &&
            string.IsNullOrWhiteSpace(tiredspeedinput.text))
        {
            Debug.Log("no hay valores");
        }
    }

    private void valoresacutales()
    {
        walkspeedtext.text = $"Velocidad de caminata actual: {playerMovement.WalkSpeed}";
        runspeedtext.text = $"Velocidad al correr actual: {playerMovement.WalkSpeed}";
        tiredspeedtext.text = $"Velocidad al estar cansado actual: {playerMovement.TiredSpeed}";
    }


}
