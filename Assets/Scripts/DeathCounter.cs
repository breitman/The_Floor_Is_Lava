using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    private static double deaths = 0;
    private static float score = 0.0f;
    public static GameObject player;
    private int frameCount;

    public Text deathCount;
    public Text scoreCount;


    private void Awake()
    {
        DontDestroyOnLoad(FindObjectOfType<Canvas>());
        DontDestroyOnLoad(gameObject);
        player = GameObject.FindWithTag("Player");
        score = 0;
        frameCount = 0;
    }

    private void Update()
    {
        if (player.transform.position.x > 0)
        {
            score += player.transform.position.x;
        }
        if (frameCount % 15 == 0)
        {
            
            scoreCount.text = "Score: " + Mathf.Floor(score).ToString();
        }
        ++frameCount;
    }

    public void IncreaseDeaths()
    {
        ++deaths;
        deathCount.text = "Deaths: " + deaths.ToString();
    }
}
