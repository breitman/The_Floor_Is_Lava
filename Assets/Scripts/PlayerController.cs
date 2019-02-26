using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed = 5;
    public float jumpForce = 10;
    private bool isFalling = false; 
    protected Rigidbody2D rb2D;
    protected SpriteRenderer sr;
    private float boxColliderSizeX;
    private float boxColliderSizeY;
    private Vector2 startingCollider;
    //public Sprite crouchSprite;
    public Sprite defaultSprite;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //boxColliderSizeX = gameObject.GetComponent<BoxCollider2D>().size.x;
        //boxColliderSizeY = gameObject.GetComponent<BoxCollider2D>().size.y;
        //startingCollider = new Vector2(boxColliderSizeX, boxColliderSizeY);
    }

    private void Update()
    {
        if (sr != null)
        {
            float movementHorizontal = 0;
            Vector2 vel = rb2D.velocity;
            //if (gameObject.GetComponent<BoxCollider2D>().size != startingCollider && !Input.GetKey(KeyCode.DownArrow))
            //{
            //    gameObject.GetComponent<BoxCollider2D>().size = startingCollider;
            //    sr.sprite = defaultSprite;
            //}

            /*if (Input.GetKey(KeyCode.DownArrow))
            {
                sr.sprite = crouchSprite;
                if (gameObject.GetComponent<BoxCollider2D>().size.y >= boxColliderSizeY)
                {
                    gameObject.GetComponent<BoxCollider2D>().size -= new Vector2(0, (.63f * boxColliderSizeY));
                }
            }*/
            if (Input.GetKeyDown(KeyCode.Space) && (vel.y == 0f || isFalling == true))
            {
                vel.y = jumpForce;
            }
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                movementHorizontal = -1;
                sr.flipX = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                movementHorizontal = 1;
                sr.flipX = false;
            }

            rb2D.velocity = new Vector3(movementHorizontal * speed, vel.y, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            destroyPlayer();
        }
        if (collision.gameObject.CompareTag("Falling"))
        {
            isFalling = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Falling"))
        {
            isFalling = false;
        }
    }



    public void destroyPlayer()
    {
        StartCoroutine(RestartTheGameAfterSeconds(1));
        Destroy(GetComponent<SpriteRenderer>());

    }

    IEnumerator RestartTheGameAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

