using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //private Transform spherePos;
    private GameObject stone;
    public bool isAnswer = false;                // 황소자리를 구성하는 구멍인지 아닌지
    public bool hasStone = false;                // 돌이 껴있는지 아닌지

    void Start()
    {
        //spherePos = transform.GetChild(0);
    }

    // 구멍에서 돌을 꺼내는 함수
    public GameObject TakeStoneOut()
    {
        if (hasStone)
        {
            hasStone = false;
            Puzzle3.instance.CheckIsAnswer(isAnswer);
            return stone;
        }

        return null;
    }

    // 돌을 구멍에 끼워넣는 함수
    public void PutStone(GameObject stone)
    {
        hasStone = true;
        stone.transform.SetParent(transform);
        stone.transform.localPosition = Vector3.zero;
        stone.GetComponent<Rigidbody>().useGravity = false;
        this.stone = stone;
        Puzzle3.instance.CheckIsAnswer(isAnswer);
    }
}
