using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLoad : MonoBehaviour
{
    private enum LoadState
    {
        idle,
        Fall,
        Reset
    }

    private LoadState loadState = LoadState.idle;

    private float curTime = 0f;
    private float fallRate = 1f;
    private int loadIndex = -1;
    private Transform left;
    private Transform right;
    private List<Transform> leftFallLoads = new List<Transform>();
    private List<Transform> rightFallLoads = new List<Transform>();

    private Vector3 leftEulerAngle;
    private Vector3 rightEulerAngle;

    private Dialogue fallLoadDialogue;

    void Start()
    {
        fallLoadDialogue = GetComponent<Dialogue>();
        left = transform.GetChild(0);
        right = transform.GetChild(1);
        foreach(Transform tr in left)
        {
            leftFallLoads.Add(tr);
        }
        foreach (Transform tr in right)
        {
            rightFallLoads.Add(tr);
        }
    }

    void Update()
    {
        switch (loadState)
        {
            case LoadState.idle:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    FallingStart();
                }
                break;

            case LoadState.Fall:
                curTime += Time.deltaTime;

                if (loadIndex < left.childCount - 1)
                {
                    if (curTime >= fallRate)
                    {
                        curTime = 0f;
                        loadIndex++;
                        leftFallLoads[loadIndex].GetComponent<Fall>().StartFall();
                        rightFallLoads[loadIndex].GetComponent<Fall>().StartFall();
                        fallRate -= (fallRate / left.childCount) * 2;
                    }
                }
                else
                {
                    if(curTime >= 3f)
                    {
                        loadIndex = -1;
                        fallRate = 1f;

                        foreach (Transform transform in leftFallLoads)
                        {
                            transform.GetComponent<Fall>().ResetPos();
                        }
                        foreach (Transform transform in rightFallLoads)
                        {
                            transform.GetComponent<Fall>().ResetPos();
                        }

                        left.localEulerAngles = leftEulerAngle = new Vector3(0, 0, -90f);
                        right.localEulerAngles = rightEulerAngle = new Vector3(0, 0, 90f);

                        loadState = LoadState.Reset;

                        curTime = 0f;
                    }
                }
                break;

            case LoadState.Reset:
                if(leftEulerAngle.z < 0)
                {
                    leftEulerAngle.z += Time.deltaTime * 45f;
                    rightEulerAngle.z -= Time.deltaTime * 45f;
                    left.eulerAngles = leftEulerAngle;
                    right.eulerAngles = rightEulerAngle;
                }
                else
                {
                    left.localEulerAngles = Vector3.zero;
                    right.localEulerAngles = Vector3.zero;
                    loadState = LoadState.idle;
                }

                SoundManagaer.instance.PlayBGM(SoundManagaer.BGM.PlayTheme);
                break;
        }
    }

    private void FallingStart()
    {
        loadState = LoadState.Fall;
        fallLoadDialogue.ShowDialogue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FallingStart();
            SoundManagaer.instance.PlayBGM(SoundManagaer.BGM.FaillingLoad);
        }
    }
}
