using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private Transform spherePos;
    public bool isAnswer = false;                // 황소자리를 구성하는 구멍인지 아닌지
    public bool hasStone = false;                // 돌이 껴있는지 아닌지

    void Start()
    {
        spherePos = transform.GetChild(0);
    }

    // 구멍에서 돌을 꺼내는 함수
    public void TakeStoneOut()
    {
        hasStone = false;
        Puzzle3.instance.CheckIsAnswer(isAnswer);
    }

    // 돌을 구멍에 끼워넣는 함수
    public void PutStone(GameObject stone)
    {
        hasStone = true;
        stone.transform.SetParent(spherePos);
        stone.transform.position = spherePos.position;
        Puzzle3.instance.CheckIsAnswer(isAnswer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name.Contains("Stone") && !hasStone)
        //{
        //    hasStone = true;
        //    collision.transform.SetParent(spherePos);
        //    collision.transform.position = spherePos.position;
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
        //if(hasStone && collision.gameObject.name.Contains("Stone"))
        //{
        //    hasStone = false;
        //    collision.transform.SetParent(null);
        //    Puzzle3.instance.CheckIsAnswer(isAnswer);
        //}
    }
}
