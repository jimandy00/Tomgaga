using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    private float lerpT = 0f;
    private readonly float targetPosX = -41f;
    private Vector3 originPos;
    private Vector3 targetPos;

    private void OnEnable()
    {
        //GetComponent<Dialogue>().ShowDialogue();
    }

    void Start()
    {
        originPos = targetPos = transform.position;
        targetPos.x = targetPosX;
    }

    void Update()
    {
        lerpT += Time.deltaTime / 10f;
        transform.position = Vector3.Lerp(originPos, targetPos, lerpT );
    }

    public void ResetTrap()
    {
        lerpT = 0f;
        transform.position = originPos;
        enabled = false;
    }
}
