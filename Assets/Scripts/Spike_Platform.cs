using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Platform : Basic_Platform
{

    public Sprite sprite;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private int currFrame;


    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        StartCoroutine(SpikeRendering());
    }

    public void Update()
    {
        //SpikeRendering();
        ++currFrame;
    }

    public IEnumerator SpikeRendering()
    {
        while (true)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            boxCollider.isTrigger = !boxCollider.isTrigger;
            yield return new WaitForSeconds(1.2f);
        }
    }

    public override void DoAction(GameObject player)
    {
        //access player game over function instead of dying
        if (spriteRenderer.enabled == true)
        {
            Destroy(player);
            GameOver();
        }
    }
}

