using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : Basic_Platform
{
    // Start is called before the first frame update
    public float fall_delay = 3;
    void Start()
    {

    }

    // Update is called once per frame
    public override void DoAction(GameObject player)
    {
        StartCoroutine(FallDelay());
    }

    IEnumerator FallDelay()
    {
        yield return new WaitForSeconds(fall_delay);
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
