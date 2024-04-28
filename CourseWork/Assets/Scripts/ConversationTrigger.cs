using UnityEngine;
using DialogueEditor;

public class ConversationTrigger : MonoBehaviour
{
    [SerializeField] private NPCConversation conversation;
    public GameObject player;
    public GameObject conversationButtonCanva;
    private PlayerLook playerLook;
    private InputManager inputManager;

    void Start()
    {
        playerLook = player.GetComponent<PlayerLook>();
        inputManager = player.GetComponent<InputManager>();
        
        conversationButtonCanva.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        conversationButtonCanva.SetActive(true);
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            playerLook.enabled = false;
            inputManager.enabled = false;
            
            Cursor.lockState = CursorLockMode.None;
            ConversationManager.Instance.StartConversation(conversation);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        conversationButtonCanva.SetActive(false);
    }

    public void OnConversationEnd()
    {
        playerLook.enabled = true;
        inputManager.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
