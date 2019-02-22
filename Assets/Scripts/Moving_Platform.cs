using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Platform : Basic_Platform
{

    private Vector3 startPosition;

    public int maxSpeed;

    public void Start()
    {
        startPosition = transform.position;
    }

    public void Update()
    {
        MoveVertical();
    }

    public void MoveVertical()
    {
        transform.position = new Vector3(transform.position.x, startPosition.y + Mathf.Sin(Time.time * maxSpeed), transform.position.z);

        if (transform.position.y > (startPosition.y +3))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else if (transform.position.y < (startPosition.y + 3))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

    public override void DoAction(GameObject player)
    {
        return;
    }
}
