using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameOver : MonoBehaviour
{
    public static GameOver instance = null;

    // canvas
    public GameObject canvas;

    // Image
    public Image img;
    Color originColor;

    // 페이드 지속 시간
    public float durationTiem ;

    // Text
    public Text text;


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

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        img.gameObject.SetActive(false);
        text.gameObject.SetActive(false);

        originColor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            StartGameOverUI();
        }
    }

    public void StartGameOverUI()
    {
        canvas.SetActive(true);
        img.gameObject.SetActive(true);
        StartCoroutine(CoChangeA());
    }

    IEnumerator CoChangeA()
    {
        print("코루틴 실행");
        float time = 0f;
        while (time < durationTiem)
        {
            print("와일문 실행");
            print(time);
            float a = Mathf.Lerp(0f, 1f, time / durationTiem);
            img.color = new Color(originColor.r, originColor.g, originColor.b, a);
            time += Time.deltaTime;
            yield return null;
        }
        img.color = new Color(originColor.r, originColor.g, originColor.b, 1f);
        yield return new WaitForSeconds(1.0f);
        text.gameObject.SetActive(true);
    }
}
