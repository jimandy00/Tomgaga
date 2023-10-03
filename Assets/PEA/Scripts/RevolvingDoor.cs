using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolvingDoor : MonoBehaviour
{
    private Puzzle1.HandleState hState = Puzzle1.HandleState.None;

    private float curTime = 0f;
    private bool isTurn = false;
    private Vector3 originEulerAngle;
    private Vector3 startEulerAngle;
    private Vector3 eulerAngle;
    private Vector3 failRot;
    private Vector3 rightRot;
    private readonly float failRotY = 0;
    private readonly float rightRotY = -90;

    private AudioSource audioSource;

    [Tooltip("숫자 커질수록 느려짐")]public float turnSpeed = 1f;
    public AnimationCurve animationCurve;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        eulerAngle = originEulerAngle = failRot = rightRot = transform.eulerAngles;
        failRot.y = failRotY;
        rightRot.y = rightRotY;
    }

    void Update()
    {
        switch (hState)
        {
            case Puzzle1.HandleState.None:
                break;

            case Puzzle1.HandleState.Left:
                if (!isTurn)
                {
                    startEulerAngle = transform.eulerAngles;
                    isTurn = true;
                }
                curTime += Time.deltaTime;
                eulerAngle = Vector3.Lerp(eulerAngle, failRot, animationCurve.Evaluate(curTime / turnSpeed));
                break;

            case Puzzle1.HandleState.Right:
                if (!isTurn)
                {
                    startEulerAngle = transform.eulerAngles;
                    isTurn = true;
                }
                curTime += Time.deltaTime;
                eulerAngle = Vector3.Lerp(eulerAngle, rightRot, animationCurve.Evaluate(curTime / turnSpeed));
                break;
        }

        if(eulerAngle.y > 180)
        {
            eulerAngle.y -= 360f;
        }

        transform.eulerAngles = eulerAngle;
    }

    public void RotateRevolvingDoor(Puzzle1.HandleState handleState)
    {
        hState = handleState;
        curTime = 0f;
    }

    public void ResetRevolvingDoor()
    {
        hState = Puzzle1.HandleState.None;
        eulerAngle = originEulerAngle;
        transform.eulerAngles = eulerAngle;
        curTime = 0f;
    }
}
