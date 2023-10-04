using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastMural : MonoBehaviour
{
    private Vector3 minoTargetPos;
    private Vector3 soldierTargerPos;

    public Transform mino;
    public Transform soldier;
    public bool isChanged = false;

    void Start()
    {
        minoTargetPos = soldier.position;
        soldierTargerPos = mino.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            ChangePos();
        }

        if (isChanged)
        {
            mino.position = Vector3.Lerp(mino.position, minoTargetPos, Time.deltaTime);
            soldier.position = Vector3.Lerp(soldier.position, soldierTargerPos, Time.deltaTime);
        }
    }

    public void ChangePos()
    {
        isChanged = true;
    }
}
