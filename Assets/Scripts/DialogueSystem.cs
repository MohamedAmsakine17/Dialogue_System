using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueSystem
{
    [TextArea(3,20)]
    [NonReorderable]
    public string[] sentences;

    public Sprite charachterSprite;
}
