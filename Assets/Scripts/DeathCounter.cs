using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathCounter : MonoBehaviour
{
    private static double deaths = 0;
    private static float score = 0.0f;
    public static GameObject player;
    private int frameCount;

    public Text deathCount;
    public Text scoreCount;

    private static DeathCounter dcInstance;


    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Scrolling Background_current")
        {
            DontDestroyOnLoad(FindObjectOfType<Canvas>());
            DontDestroyOnLoad(FindObjectOfType<Camera>());

            if(dcInstance == null)
            {
                DontDestroyOnLoad(this);
                dcInstance = this;
            }

            player = GameObject.FindWithTag("Player");
            score = 0;
            frameCount = 0;

        }
        else
        {
            //GameObject.Find("DontDestroyOnLoad").active = false;
        }
    }

    private void Update()
    {

        if(SceneManager.GetActiveScene().name == "Game_Over")
        {
            scoreCount.text = Mathf.Floor(score).ToString();
            //GameObject.Find("GameManager").GetComponent<DeathCounter>().scoreCount.text = Mathf.Floor(score).ToString();
        }
        else
        {
            score += Time.deltaTime;
            if (frameCount % 15 == 0)
            {

                scoreCount.text = "Score: " + Mathf.Floor(score).ToString();
            }
            ++frameCount;
        }
    }

    public void IncreaseDeaths()
    {
        if (SceneManager.GetActiveScene().name != "Game_Over")
        {
            ++deaths;
            deathCount.text = "Deaths: " + deaths.ToString();
        }
    }
}
