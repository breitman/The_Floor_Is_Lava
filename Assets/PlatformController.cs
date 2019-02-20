using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private float useSpeed;
    public float directionSpeed;
    float origX;
    
    // Start is called before the first frame update
    void Start()
    {
        origX = transform.position.x;
        useSpeed = -directionSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(useSpeed * Time.deltaTime, 0, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
