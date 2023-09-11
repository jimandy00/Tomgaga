using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public static HoleManager instance = null;

    private bool isAnswer = false;

    private List<Hole> holes = new List<Hole>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        foreach (Transform  tr in transform)
        {
            holes.Add(tr.GetComponent<Hole>());
        }
    }

    void Update()
    {

    }

    public void CheckIsAnswer()
    {
        foreach(Hole hole in holes)
        {
            if (hole.isAnswer)
            {
                if (!hole.hasStone)
                {
                    isAnswer = false;
                    print(isAnswer);
                    return;
                }
            }
            else
            {
                if (hole.hasStone)
                {
                    isAnswer = false;
                    print(isAnswer);
                    return;
                }
            }
        }

        isAnswer = true;
        print(isAnswer);
    }
}
