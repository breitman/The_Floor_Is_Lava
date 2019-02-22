using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] objects;
    public float spawnMin;
    public float spawnMax;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(objects[Random.Range(0, objects.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
