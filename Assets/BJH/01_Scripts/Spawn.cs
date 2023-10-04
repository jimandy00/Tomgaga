using Oculus.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.UI;

// ���� ����Ʈ ���� ������ �÷��̾ �����Ǹ�
// �÷��̾ ���� ������ �� ���� ����Ʈ�� �÷��̾ ��ġ��Ų��.
public class Spawn : MonoBehaviour
{
    Player player;
    public GameObject originSpawnPoint;

    bool spawnState;

    PlayerDie playerDie;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        player.savedSpawnPoint = originSpawnPoint.transform.position; // spawnPoint01�� ��ġ�� �ʱ�ȭ

        playerDie = GetComponent<PlayerDie>();
    }

    public bool completeRespawn;
    public void ReSpawn()
    {
        print("������ ����ǳ�?");
        transform.position = player.savedSpawnPoint; // ����� ���� ����Ʈ�� �÷��̾� �̵�
        GameManager.instance.PuzzlesReset(); // ���� ����
        player.playerState = true; // �÷��̾� ���� '����'���� ����
        completeRespawn = true;
        //playerDie.pushZ = false;
        print(playerDie.pushZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint")) // �÷��̾ Ʈ���ſ� ���̸�?
        {
            player.savedSpawnPoint = other.transform.position; // �÷��̾� ���� ����Ʈ ����
            print("���� ����Ʈ ���� : " + other.gameObject.name);
        }
    }
}