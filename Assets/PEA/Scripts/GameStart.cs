using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PEA
{
    public class GameStart : MonoBehaviour
    {
        public void OnClickStart()
        {
            SceneManager.LoadScene("PrologueScene");
        }
    }

}
