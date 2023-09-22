using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{
    public Dialogue startDialogue;

    void Start()
    {
        DialogueManager.instance.dialogueText = GetComponent<TMP_Text>();

        startDialogue.ShowDialogue();
    }
}
