using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dialogue : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dialogue"))
        {
            other.GetComponent<Dialogue>().ShowDialogue();

            if (other.name.Contains("Entry") && other.name.Contains("Puzzle"))
            {
                if (SoundManager.instance != null)
                {
                    SoundManager.instance.PlayBGM(SoundManager.BGM.Puzzle);
                }
            }
        }
    }

}
