using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Platform : Basic_Platform
{
    public override void DoAction(GameObject player)
    {
        //access player game over function instead of dying
        Destroy(player);
        GameOver();
    }
}

