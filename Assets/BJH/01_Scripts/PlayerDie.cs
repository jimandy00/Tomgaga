using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 플레이어가 죽으면
// 사운드를 제생하고
// 사망했습니다. UI를 실행

public class PlayerDie : MonoBehaviour
{
    public Spawn spawn;
    Player player;

    [SerializeField]
    PlayerMove playerMove;
    public AudioSource audioSource;

    public OVRInput.Button Abutton; // one
    public OVRInput.Controller Rcontroller; // RTouch

    // 0 : 플레이어 가시에 찔림
    // 1 : 플레이어 세상 밖으로 떨어짐
    // 2 : 플레이어가 죽었습니다. UI
    // 3 : 컨트롤러 버튼 누름
    public AudioClip[] audio;
    bool audioState;

    public GameObject uiObject;
    Image ui;

    bool uiState;

    public float fadeDuration; // 지속시간
    public float fadeDuration2; // 지속시간
    Color originColor;
    Color transColor;

    public GameObject brushObject;
    Image brushImage;
    Color brushOriginColor;
    Color brushTransColor;

    // retry함수를 자동으로 실행 시킬 bool값 만들기
    bool isRetry;

    // 재시작 버튼
    public Text aBtn;
    float aBtnDuration = 1f;

    private Coroutine coroutine = null;

    


    void Start()
    {
        uiState = false;

        uiObject.SetActive(false);
        ui = uiObject.GetComponent<Image>();

        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>(); // 모든 컴포넌트 가져오기 없지롱

        originColor = ui.color;

        transColor = new Color(originColor.r, originColor.g, originColor.b, 0f);

        // ui가 시작할 때 투명하게 시작
        ui.color = transColor;


        brushImage = brushObject.GetComponent<Image>();
        brushOriginColor = brushImage.color;
        brushTransColor = brushOriginColor;
        brushTransColor.a = 0f;
        brushImage.color = brushTransColor; // 투명하게 시작


    }

    // Update is called once per frame
    void Update()
    {
        // 플레이어가 죽었고, 오디오가 플레이되지 않았으면
        if (player.playerState == false && audioState == false)
        {
            PlayAudio(2);
            Die();
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
        Debug.Log(idx + "번 오디오가 실행되었습니다.");
        audioState = true;
    }

    // 플레이어 죽음
    public void Die()
    {
        uiObject.SetActive(true);

        StartCoroutine(CoUi()); // ui 깜박깜박

        isRetry = true;
    }

    

    IEnumerator CoUi()
    {
        print("코루틴 실행");
        uiState = true;

        float time01 = 0f;

        while (time01 < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, time01 / fadeDuration);
            ui.color = new Color(originColor.r, originColor.g, originColor.b, alpha); // bg
            time01 += Time.deltaTime;
            yield return null;
        }

        float time02 = 0f;

        while (time02 < fadeDuration2)
        {
            float alpha = Mathf.Lerp(0f, 1f, time02 / fadeDuration2);
            brushTransColor.a = alpha;
            brushImage.color = brushTransColor;
            time02 += Time.deltaTime;
            yield return null;
        }

        ui.color = originColor;
        brushImage.color = brushOriginColor;
        
    }

    private void Retry()
    {
        if(coroutine == null)
        {
            coroutine = StartCoroutine(CoABtn());
        }

        if (OVRInput.GetDown(Abutton, Rcontroller) || Input.GetKeyDown(KeyCode.Z))
        {
            // 버튼 클릭하는 소리
            audioSource.clip = audio[3];


            //// 스폰 포인트에서 다시 시작
            //transform.position = spawn.savedSpawnPoint;

            // 플레이어 살아남
            player.playerState = true;

            // 오디오 초기화
            audioState = false;

            // Ui 끄기
            uiObject.SetActive(false);
            uiState = false;

            // retry값 끄기
            isRetry = false;

            //spawn.ReSpawn();

        }
    }

    IEnumerator CoABtn()
    {
        aBtn.gameObject.SetActive(true);
        while (true)
        {
            aBtn.enabled = !aBtn.enabled;

            if (OVRInput.GetDown(Abutton, Rcontroller) || Input.GetKeyDown(KeyCode.Z))
            {
                break;
            }
            yield return new WaitForSeconds(aBtnDuration);
        }
        aBtn.gameObject.SetActive(false);
        coroutine = null;
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