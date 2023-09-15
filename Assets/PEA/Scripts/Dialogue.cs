using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public int dialogueNum;
    public int dialogueEndNum;
    public bool isPrologue = false;

    public void ShowDialogue(System.Action action = null)
    {
        DialogueManager.instance.ShowDialogue(dialogueNum, dialogueEndNum, isPrologue, action);
    }
}
