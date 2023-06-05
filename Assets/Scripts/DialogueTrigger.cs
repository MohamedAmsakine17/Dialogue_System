using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSystem dialogueSystem;

    public void OnClick()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogueSystem);
    }
}
