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
        float yPos = Random.Range(Random.Range(-5f,-3f), lastSpawnPos.y+ 3f);
        while(yPos+lastSpawnPos.y > 5)
        {
            yPos = Random.Range(Random.Range(-5f,-3f), lastSpawnPos.y + 3f);
        }


        Vector3 spawnPos = new Vector3(transform.position.x, yPos, playerPos.z);
        lastSpawnPos = spawnPos;

        Instantiate(objects[Random.Range(0, objects.GetLength(0))], spawnPos, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));


    }
}
