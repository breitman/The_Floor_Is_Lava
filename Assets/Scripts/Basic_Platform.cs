using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Basic_Platform : MonoBehaviour
{

    private Rigidbody2D player;
    private GameObject target = null;
    private Vector3 offset;

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        target = null;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.collider.transform.SetParent(transform);
            DoAction(other.gameObject);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }


    public abstract void DoAction(GameObject player);

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
