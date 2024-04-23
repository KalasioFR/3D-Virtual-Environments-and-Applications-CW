using UnityEngine;
using DialogueEditor;

public class ConversationTrigger : MonoBehaviour
{
    [SerializeField] private NPCConversation conversation;
    public GameObject conversationButtonCanva;

    void Start()
    {
        conversationButtonCanva.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            conversationButtonCanva.SetActive(true);
            if(Input.GetKeyDown(KeyCode.F))
            {
                Cursor.lockState = CursorLockMode.None;
                ConversationManager.Instance.StartConversation(conversation);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        conversationButtonCanva.SetActive(false);
    }

    public void OnConversationEnd()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
