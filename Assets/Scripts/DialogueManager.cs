using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] GameObject GameCanvas;
    [SerializeField] GameObject DialoguePanel;

    [Header("Dialogue Para")]
    [SerializeField] float dialogueDelay;
    float delay;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] Image charachterSprite;

    Queue<string> dialogueSentences = new Queue<string>();

    bool continueDialogue = false;

    public void StartDialogue(DialogueSystem dialogueSystem)
    {
        GameCanvas.GetComponent<Animator>().SetTrigger("Display Off");

        delay = dialogueDelay;

        charachterSprite.sprite = dialogueSystem.charachterSprite;

        StartCoroutine(DisplayDialoguePanel());

        foreach(var sentence in dialogueSystem.sentences)
        {
            dialogueSentences.Enqueue(sentence);
        } 
    }


    IEnumerator DisplayDialoguePanel() {

        yield return new WaitForSeconds(0.5f);
        DialoguePanel.SetActive(true);


        yield return new WaitForSeconds(0.5f);
        DisplayNextSentence();
        FindObjectOfType<PlayerManager>().PlayerState = PlayerState.Talking;
    }

    public void DisplayNextSentence()
    {
        if(dialogueSentences.Count <= 0) { EndDialogue(); return; }

        if(!continueDialogue) {
            StopAllCoroutines();
            StartCoroutine(WriteSentence(dialogueSentences.Dequeue()));
            continueDialogue= true;
            delay = dialogueDelay;
        }
        else
        {
            delay = 0f;
        }
        
    }

    IEnumerator WriteSentence(string sentence)
    {
        dialogueText.text= "";

        foreach(char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            if(dialogueText.text == sentence)
            {
                continueDialogue = false;
            }
            yield return new WaitForSeconds(delay);
        }
    }

    void EndDialogue() 
    {
        DialoguePanel.GetComponent<Animator>().SetTrigger("Display Off");
    }
}
