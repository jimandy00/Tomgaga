using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance = null;

    private string curShowingDialogue;
    private Coroutine coroutine = null;
    private AudioSource dialogueAudioSource;

    private Dictionary<int, string> dialogues = new Dictionary<int, string>();

    public string dialogueCSVPath;
    public TMP_Text dialogueText;

    public AudioClip[] dialogueAudioClips;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ReadDialogueCSV(Resources.Load<TextAsset>(dialogueCSVPath));
        dialogueAudioSource = GetComponent<AudioSource>();
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
        dialogueAudioSource.PlayOneShot(dialogueAudioClips[dialogueNum - 1]);

        if (isPrologue)
        {
            PrologueManager.instance.ShowPrologueImage(dialogueNum);
        }

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
        else if (isPrologue)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(dialogueNum == 36)
        {
            GameOver.instance.StartGameOverUI();
        }

        coroutine = null;
        yield return null;
    }
}
