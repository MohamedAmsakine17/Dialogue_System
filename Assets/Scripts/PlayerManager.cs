using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum PlayerState { Walking,Talking}
public class PlayerManager : MonoBehaviour
{
    public PlayerState PlayerState { get; set; }
    void OnNextSentence(InputValue value)
    {
        if (value.isPressed)
        {
            if(PlayerState == PlayerState.Talking) 
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }
}
