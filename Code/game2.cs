using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class game2 : MonoBehaviour
{
    private float timer;
    private GameObject timeText;
    private bool gameRunning;
    private float stopTimer;
    private GameObject player;
    public bool completed;
    public bool warning;
    private GameObject warningText;
    private float warningTimer;
    private bool blink;
    public GameObject downArrow;
    private GameObject downArrowInst;
    public bool arrowFalling;

    void Start()
    {
        this.timer = 0f;
        this.timeText = GameObject.Find("timeText");
        this.gameRunning = true;
        this.player = GameObject.Find("RollerBall");
        this.completed = false;
        this.warning = false;
        this.warningText = GameObject.Find("warningText");
        this.warningTimer = 0f;
        this.blink = true;
        this.arrowFalling = false;
    }

    
    void Update()
    {
        this.timer += Time.deltaTime * 1f;

        if (gameRunning)
        {
            this.timeText.GetComponent<Text>().text = "Time: " + timer.ToString("0.00");
        }

        if (!gameRunning && (timer - stopTimer) > 3f)
        {
            SceneManager.LoadScene(4);
        }

        if (!warning)
        {
            this.warningText.GetComponent<Text>().enabled = false;
        }

        if (warning)
        {
            if (timer > warningTimer)
            {
                warningTimer = timer + 0.3f;
                blink = true;
            }

            if (blink)
                {
                if (this.warningText.GetComponent<Text>().enabled)
                {
                    this.warningText.GetComponent<Text>().enabled = false;
                }
                else
                {
                    this.warningText.GetComponent<Text>().enabled = true;
                }
                blink = false;
            }
        }

        if (!arrowFalling)
        {
            downArrowInst = Instantiate(downArrow, new Vector3(540.8f, 15f, -1014f), Quaternion.Euler(90f, 0f, 180f));
            this.arrowFalling = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void stopGame()
    {
        if (completed)
        {
            PlayerPrefs.SetFloat("time", stopTimer);
            PlayerPrefs.SetInt("completed", 1);
        }
        if (!completed)
        {
            PlayerPrefs.SetInt("completed", 0);
        }
        this.stopTimer = timer;
        PlayerPrefs.SetInt("game", 2);
        this.gameRunning = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Rigidbody>().useGravity = false;
    }
}
                    