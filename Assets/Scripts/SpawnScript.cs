using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject player;
    public float spawnMin;
    public float spawnMax;
    Vector3 lastSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        lastSpawnPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }



    void Spawn()
    {
        //float xPos = Random.Range(9.0f, 10.5f);
        //float yPos = Random.Range(-4.5f, 4.5f);
        //Vector2 pos = new Vector2(xPos, yPos);

        Vector3 playerPos = player.transform.position;
        //Vector3 playerJumpRange = player.transform.up;
        //Vector3 playerForward = player.transform.forward;
        //float spawnDistance = Random.Range(-4, 4);
        //float xOffset = 10;
        //float yOffset = Random.Range(-8, 8);

        //float xPos = 8;
        float yPos = Random.Range(Random.Range(-5f, -3f), lastSpawnPos.y + 3f);
        while (yPos + lastSpawnPos.y > 5)
        {
            yPos = Random.Range(Random.Range(-5f, -3f), lastSpawnPos.y + 3f);
        }


        Vector3 spawnPos = new Vector3(transform.position.x, yPos, playerPos.z);
        lastSpawnPos = spawnPos;

        Instantiate(objects[biasedRandomGenerator()], spawnPos, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));


    }
    int biasedRandomGenerator()
    {
        /*
         0 = basic
         1 = square
         2 = falling
         3 = bounce 
         4 = spike
         5 = move
         */

        int RandomNum = Random.Range(1, 18);

        switch (RandomNum)
        {
            case 15:
            case 9:
            case 5:
            case 18:
            case 3:
            case 11:
            case 17:
            case 1:
                return 0; //basic
            case 7:
                return 4;//spike
            case 6:
            case 4:
                return 2;//falling
            case 16:
            case 14:
                return 3;//
            case 10:
            case 13:
                return 5;//moving
            case 2:
            case 8:
            case 12:
                return 1;//bouncy
            default:
                return 0;
        }
    }
}
