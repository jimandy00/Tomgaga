using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool playerState;
    public Vector3 savedSpawnPoint;
    public PlayerDie playerDie;

    Spawn spawn;
    void Start()
    {
        playerDie = GetComponent<PlayerDie>();
        playerState = true;

        spawn = GetComponent<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            playerState = false;
        }

        //if (playerDie.pushZ == true)
        //{
        //    print("아니 왜 계속 뜨지?");
        //    spawn.ReSpawn();
            
        //    playerDie.pushZ = false;
        //}

        if(spawn.completeRespawn == true)
        {

        }
    }

    IEnumerator coroutine;
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.name == "TreasureChest")
        {
            print("실행됨");
            coroutine = dieDelay();
            if (coroutine != null)
            {
                StartCoroutine(coroutine);
            }
        }
    }

    IEnumerator dieDelay()
    {
        print("코루틴 실행됨");
        yield return new WaitForSeconds(3f);
        coroutine = null;
        playerState = false;
    }
}


