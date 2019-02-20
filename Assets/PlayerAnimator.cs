using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Sprite[] idleSprites = new Sprite[6];
    public Sprite[] sideSprites = new Sprite[6];
    public Sprite[] jumpSprites = new Sprite[6];
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private PlayerController pc;
    private int curFrame;
    private int curFrameDur;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        pc = GetComponent<PlayerController>();
        curFrame = 0;
        curFrameDur = 0;
    }

    void Update()
    {
        if (spriteRenderer != null)
        {
            Vector2 velocity = rigidBody.velocity;
            if(velocity.x >= 0 && velocity.y != 0 && !Input.GetKey(KeyCode.DownArrow))
            {
                spriteRenderer.flipX = false;
                if (curFrameDur == 5)
                {
                    if (curFrame < 5)
                    {
                        ++curFrame;
                    }
                    else
                    {
                        curFrame = 0;
                    }
                    spriteRenderer.sprite = jumpSprites[curFrame];
                    curFrameDur = 0;
                }
                else
                {
                    ++curFrameDur;
                }
            }
            else if (velocity.x < 0 && velocity.y != 0 && !Input.GetKey(KeyCode.DownArrow))
            {
                spriteRenderer.flipX = true;
                if (curFrameDur == 5)
                {
                    if (curFrame < 5)
                    {
                        ++curFrame;
                    }
                    else
                    {
                        curFrame = 0;
                    }
                    spriteRenderer.sprite = jumpSprites[curFrame];
                    curFrameDur = 0;
                }
                else
                {
                    ++curFrameDur;
                }
            }
            else if (velocity.x > 0 && !Input.GetKey(KeyCode.DownArrow))
                {
                    //rightSprite
                    spriteRenderer.flipX = false;
                    if (curFrameDur == 5)
                    {
                        if (curFrame < 5)
                        {
                            ++curFrame;
                        }
                        else
                        {
                            curFrame = 0;
                        }
                        spriteRenderer.sprite = sideSprites[curFrame];
                        curFrameDur = 0;
                    }
                    else
                    {
                        ++curFrameDur;
                    }
            }
            else if (velocity.x < 0 && !Input.GetKey(KeyCode.DownArrow))
            {
                //leftSprite
                spriteRenderer.flipX = true;
                if (curFrameDur == 5)
                {
                    if (curFrame < 5)
                    {
                        ++curFrame;
                    }
                    else
                    {
                        curFrame = 0;
                    }
                    spriteRenderer.sprite = sideSprites[curFrame];
                    curFrameDur = 0;
                }
                else
                {
                    ++curFrameDur;
                }
            }

            else if (velocity.x == 0 && velocity.y == 0 && !Input.GetKey(KeyCode.DownArrow))
            {
                //defaultSprite
                if (curFrameDur == 5)
                {
                    if (curFrame < 5)
                    {
                        ++curFrame;
                    }
                    else
                    {
                        curFrame = 0;
                    }
                    spriteRenderer.sprite = idleSprites[curFrame];
                    curFrameDur = 0;
                }
                else
                {
                    ++curFrameDur;
                }

            }
        }
    }
}
