using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;

    private string curShowingDialogue;
    private Coroutine coroutine = null;

    public string dialogueCSVPath;

    public TMP_Text dialogueText;

    private Dictionary<int, string> dialogues = new Dictionary<int, string>();


    private int n = 0;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        ReadDialogueCSV(Resources.Load<TextAsset>(dialogueCSVPath));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            n++;
            ShowDialogue(n);
        }
    }

    public void ReadDialogueCSV(TextAsset csvData)
    {
        string[] data = csvData.text.Split('\n');

        for (int i = 0; i < data.Length; i++)
        {
            string[] row = data[i].Split(',');

            //print(int.Parse(row[1]) + " : " + row[1]);
            dialogues.Add(int.Parse(row[0]), row[1]);
        }
    }

    public void ShowDialogue(int dialogueNum)
    {
        if(dialogues.TryGetValue(dialogueNum, out curShowingDialogue))
        {
            if(coroutine == null)
            {
                coroutine = StartCoroutine(TypeDialogue());
            }
        }
        else
        {
            print(dialogueNum + ", 해당 번호에 맞는 대사없음");
        }
    }

    IEnumerator TypeDialogue()
    {
        for (int i = 0; i < curShowingDialogue.Length; i++)
        {
            dialogueText.text += curShowingDialogue[i];
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);

        dialogueText.text = "";
        coroutine = null;
        yield return null;
    }
}
