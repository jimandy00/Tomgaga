using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{
    void Start()
    {
        DialogueManager.instance.dialogueText = GetComponent<TMP_Text>();
    }
}
