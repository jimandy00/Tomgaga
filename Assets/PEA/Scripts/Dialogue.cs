using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public int dialogueNum;
    public int dialogueEndNum;


    public void ShowDialogue()
    {
        DialogueManager.instance.ShowDialogue(dialogueNum, dialogueEndNum);
    }
}
