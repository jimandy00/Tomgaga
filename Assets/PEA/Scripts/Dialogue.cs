using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private bool canShow = true;

    public int dialogueNum;
    public int dialogueEndNum;
    public bool isPrologue = false;
    public bool oneTime = false;

    public void ShowDialogue()
    {
        if (canShow)
        {
            DialogueManager.instance.ShowDialogue(dialogueNum, dialogueEndNum, isPrologue);

            if (oneTime)
            {
                canShow = false;
            }
        }
    }
}
