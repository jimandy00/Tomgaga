using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �÷��̾ ������
// ���带 �����ϰ�
// ����߽��ϴ�. UI�� ����

public class PlayerDie : MonoBehaviour
{
    Spawn spawn;
    Player player;

    PlayerMove playerMove;
    public AudioSource audioSource;

    public OVRInput.Button Abutton; // one
    public OVRInput.Controller Rcontroller; // RTouch

    // 0 : �÷��̾� ���ÿ� ��
    // 1 : �÷��̾� ���� ������ ������
    // 2 : �÷��̾ �׾����ϴ�. UI
    // 3 : ��Ʈ�ѷ� ��ư ����
    public AudioClip[] audio;
    bool audioState;

    public GameObject uiObject;
    Image ui;
    Text text;
    Color textOriginColor;
    Color textTransColor;

    bool uiState;

    public float fadeDuration; // ���ӽð�
    public float fadeDuration2; // ���ӽð�
    Color originColor;
    Color transColor;

    public GameObject brushObject;
    Image brushImage;
    Color brushOriginColor;
    Color brushTransColor;

    // retry�Լ��� �ڵ����� ���� ��ų bool�� �����
    bool isRetry;

    // ����� ��ư
    public Text aBtn;
    float aBtnDuration = 1f;

    private Coroutine coroutine = null;

    


    void Start()
    {
        spawn = GetComponent<Spawn>();

        uiState = false;

        uiObject.SetActive(false);
        ui = uiObject.GetComponentInChildren<Image>();

        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>(); // ��� ������Ʈ �������� ������

        originColor = ui.color;

        transColor = new Color(originColor.r, originColor.g, originColor.b, 0f);

        // ui�� ������ �� �����ϰ� ����
        ui.color = transColor;


        brushImage = brushObject.GetComponent<Image>();
        brushOriginColor = brushImage.color;
        brushTransColor = brushOriginColor;
        brushTransColor.a = 0f;
        brushImage.color = brushTransColor; // �����ϰ� ����

        text = ui.gameObject.GetComponentInChildren<Text>();
        textOriginColor = text.color;
        textTransColor = textOriginColor;
        textTransColor.a = 0f;
        text.color = textTransColor; // �����ϰ� ����

        player = GetComponent<Player>();
        
        print(player.name);

    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            // �÷��̾ �׾���, ������� �÷��̵��� �ʾ�����
            if (player.playerState == false && audioState == false && dieMethodState == false)
            {
                PlayAudio(2);
                Die();
                
            }
        }



        if (isRetry == true)
        {
            Retry();
        }
    }

    private void PlayAudio(int idx)
    {
        audioSource.clip = audio[idx];
        audioSource.Play();
        Debug.Log(idx + "�� ������� ����Ǿ����ϴ�.");
        audioState = true;
    }

    // �÷��̾� ����
    bool dieMethodState;
    public void Die()
    {
        uiObject.SetActive(true);

        StartCoroutine(CoUi()); // ui ���ڱ��� // null

        isRetry = true;
        dieMethodState = true;
    }

    

    IEnumerator CoUi()
    {
        print("�ڷ�ƾ ����");
        uiState = true;

        float time01 = 0f;

        while (time01 < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 0.78f, time01 / fadeDuration);
            ui.color = new Color(originColor.r, originColor.g, originColor.b, alpha); // bg
            time01 += Time.deltaTime;
            yield return null;
        }

        float time02 = 0f;

        while (time02 < fadeDuration2)
        {
            float alpha = Mathf.Lerp(0f, 1f, time02 / fadeDuration2);
            brushTransColor.a = alpha;
            textTransColor.a = alpha;

            brushImage.color = brushTransColor;
            text.color = textTransColor;

            time02 += Time.deltaTime;
            yield return null;
        }

        ui.color = originColor;
        brushImage.color = brushOriginColor;
        text.color = textOriginColor;
        
    }

    public bool pushZ;
    private void Retry()
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(CoABtn()); // �ٽ� �����Ϸ��� A��ư�� ��������.
        }
        else
        {
            if(OVRInput.GetDown(Abutton, Rcontroller) || Input.GetKeyDown(KeyCode.Z))
            {
                // ��ư Ŭ���ϴ� �Ҹ�
                audioSource.clip = audio[3];

                StopCoroutine(coroutine);

                //// ���� ����Ʈ���� �ٽ� ����
                //transform.position = spawn.savedSpawnPoint;

                // �÷��̾� ��Ƴ�
                player.playerState = true;
                dieMethodState = false;

                // ����� �ʱ�ȭ
                audioState = false;

                // Ui ����
                uiObject.SetActive(false);
                uiState = false;

                // retry�� ����
                isRetry = false;

                //spawn.ReSpawn();
                aBtn.gameObject.SetActive(false);
                coroutine = null;
                //pushZ = true;

                spawn.ReSpawn();
            }
        }
    }


    IEnumerator CoABtn()
    {
        aBtn.gameObject.SetActive(true);
        while (true)
        {
            aBtn.enabled = !aBtn.enabled;

            //yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(aBtnDuration);
        }
        //aBtn.gameObject.SetActive(false);
        //coroutine = null;
        //pushZ = true;
        //print("dfdfdf : " + pushZ);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("999999999999999");
        if(other.CompareTag("DieTrap"))
        {
            print("0000000000");
            player.playerState = false;
            //Die();
        }
    }
}