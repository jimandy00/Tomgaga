using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrologueManager : MonoBehaviour
{
    public static PrologueManager instance;

    private float imageFadeSpeed = 1f;
    private bool isSTart = false;
    private Coroutine coroutine = null;

    private Dialogue prologueDialogue;
    private Color color;

    public Image curImage;
    public Sprite[] prologueSprites;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        prologueDialogue = GetComponent<Dialogue>();
        color = curImage.color;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space )&& !isSTart)
        {
            prologueDialogue.ShowDialogue(); 
        }
    }

    public void ShowPrologueImage(int spriteNum)
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(IShowImage(spriteNum));
        }
    }

    public void FadeOutImage()
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(IFadeOutImgae());
        }
    }

    IEnumerator IShowImage(int spriteNum)
    {
        while (color.a > 0)
        {
            color.a -= Time.deltaTime * imageFadeSpeed;
            curImage.color = color;
            yield return new WaitForEndOfFrame();
        }

        curImage.sprite = prologueSprites[spriteNum];
        yield return null;

        while(color.a < 1)
        {
            color.a += Time.deltaTime * imageFadeSpeed;
            curImage.color = color;
            yield return new WaitForEndOfFrame();
        }

        coroutine = null;
        yield return null;
    }

    IEnumerator IFadeOutImgae()
    {
        while (color.a > 0)
        {
            color.a -= Time.deltaTime * imageFadeSpeed;
            curImage.color = color;
            yield return new WaitForEndOfFrame();
        }
    }
}
