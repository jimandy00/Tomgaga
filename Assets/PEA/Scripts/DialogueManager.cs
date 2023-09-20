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

    }

    public void ReadDialogueCSV(TextAsset csvData)
    {
        string[] data = csvData.text.Split('\n');

        for (int i = 0; i < data.Length; i++)
        {
            string[] row = data[i].Split(',');

            dialogues.Add(int.Parse(row[0]), row[1]);
        }
    }

    public void ShowDialogue(int dialogueNum, int dialogueEndNum, bool isPrologue = false)
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(TypeDialogue(dialogueNum, dialogueEndNum, isPrologue));
        }
    }

    IEnumerator TypeDialogue(int dialogueNum, int dialogueEndNum, bool isPrologue)
    {
        PrologueManager.instance.ShowPrologueImage(dialogueNum - 1);
        if (dialogues.TryGetValue(dialogueNum, out curShowingDialogue))
        {
            for (int i = 0; i < curShowingDialogue.Length; i++)
            {
                dialogueText.text += curShowingDialogue[i];
                yield return new WaitForSeconds(0.05f);
            }

            yield return new WaitForSeconds(3f);
        }
        else
        {
            print(dialogueNum + ", 해당 번호에 맞는 지문없음");
        }

        dialogueText.text = "";

        if(dialogueNum < dialogueEndNum)
        {
            yield return TypeDialogue(++dialogueNum, dialogueEndNum, isPrologue);
        }

        coroutine = null;
        yield return null;
    }
}
