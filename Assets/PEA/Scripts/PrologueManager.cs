using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PrologueImage
{
    public Sprite[] sprites;
}

public class PrologueManager : MonoBehaviour
{
    public static PrologueManager instance;

    private float imageStaySeconds = 3f;
    private float imageFadeSpeedMin = 2.5f;
    private bool isSTart = false;
    private Coroutine coroutine = null;

    private Dialogue prologueDialogue;
    private Color color;
    private Material material;
    private float dissolveRange = 0f;

    public Image curImage;

    [SerializeField]
    public PrologueImage[] prologueSprites;   

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        prologueDialogue = GetComponent<Dialogue>();
        color = curImage.color;
        material = curImage.material;
        dissolveRange = material.GetFloat("_DissolveRange"); 

        if(SoundManagaer.instance != null)
        {
            SoundManagaer.instance.PlayBGM(SoundManagaer.BGM.Prologue);
        }
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space ) || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))&& !isSTart)
        {
            prologueDialogue.ShowDialogue(); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowPrologueImage(6);
        }
    }

    public void ShowPrologueImage(int prologueNum)
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(IShowImage(prologueNum));
        }
    }

    IEnumerator IShowImage(int prologueNum)
    {
        for (int j = 0; j < prologueSprites[prologueNum - 1].sprites.Length; j++)
        {
            curImage.sprite = prologueSprites[prologueNum - 1].sprites[j];
            float imageFadeSpeed = j == 0 || j == prologueSprites[prologueNum - 1].sprites.Length - 1 ? imageFadeSpeedMin  : imageFadeSpeedMin * prologueSprites[prologueNum - 1].sprites.Length;

            while (dissolveRange > 0f)
            {
                //color.a += Time.deltaTime * imageFadeSpeed;
                //curImage.color = color;
                dissolveRange -= Time.deltaTime * imageFadeSpeed;
                material.SetFloat("_DissolveRange", dissolveRange);

                yield return new WaitForEndOfFrame();
            }

            yield return new WaitForSeconds(imageStaySeconds / prologueSprites[prologueNum - 1].sprites.Length);

            while (dissolveRange < 1.5f)
            {
                //color.a -= Time.deltaTime * imageFadeSpeed;
                //curImage.color = color;
                dissolveRange += Time.deltaTime * imageFadeSpeed;
                material.SetFloat("_DissolveRange", dissolveRange);
                yield return new WaitForEndOfFrame();
            }

        }

        //if (prologueNum == prologueSprites.Length)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}

        coroutine = null;
        yield return null;
    }

    //IEnumerator IFadeOutImage()
    //{
    //    while (color.a > 0)
    //    {
    //        color.a -= Time.deltaTime * imageFadeSpeed;
    //        curImage.color = color;
    //        yield return new WaitForEndOfFrame();
    //    }

    //    yield return new WaitForSeconds(0.5f);
    //}
}
