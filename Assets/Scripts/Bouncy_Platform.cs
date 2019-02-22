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
        //float time = 3f;
        //float y = player.transform.position.y;
        //Vector3 position = player.transform.position;
        //while (time > 0f)
        //{
        //    y += 1;
        //    player.transform.position = new Vector3(position.x, y, position.z);
        //    time = time - Time.deltaTime;
        //}
    }

    private IEnumerator OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.sprite = up_sprite;
        }
    }
}
