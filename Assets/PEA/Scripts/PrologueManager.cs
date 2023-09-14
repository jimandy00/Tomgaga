using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueManager : MonoBehaviour
{
    public static PrologueManager instance;

    private bool isSTart = false;

    private Dialogue prologueDialogue;

    public Image curImage;
    public Image[] prologueImages;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        prologueDialogue = GetComponent<Dialogue>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space )&& !isSTart)
        {
            prologueDialogue.ShowDialogue();
        }
    }

    public void ShowPrologueImage(int imageNum)
    {

    }

    IEnumerator ImageFadeInOut(int imageNum)
    {
        yield return null;
    }
}
