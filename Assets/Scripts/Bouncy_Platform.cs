using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy_Platform : Basic_Platform
{
    private SpriteRenderer spriteRenderer;

    public Sprite down_sprite, up_sprite;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public override void DoAction(GameObject player)
    {

        spriteRenderer.sprite = down_sprite;
    }

    private IEnumerator OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.collider.transform.SetParent(null);
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.sprite = up_sprite;
        }
    }
}
