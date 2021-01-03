using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class gameover : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("game") == 1)
        {
            GameObject.Find("scoreText").GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("score").ToString();
            GameObject.Find("Canvas2").GetComponent<Canvas>().enabled = true;
        }
        else if ((PlayerPrefs.GetInt("game") == 2) && (PlayerPrefs.GetInt("completed") == 1))
        {
            GameObject.Find("scoreText").GetComponent<Text>().text = "Time: " + PlayerPrefs.GetFloat("time").ToString("0.00");
            GameObject.Find("gameoverText").GetComponent<Text>().text = "Good Job!";
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        }
        else if ((PlayerPrefs.GetInt("game") == 2) && (PlayerPrefs.GetInt("completed") == 0))
        {
            GameObject.Find("scoreText").GetComponent<Text>().text = "";
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
