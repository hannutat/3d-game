using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{
    private float timer;
    private float nextSpawn;
    public bool treasureInGame;
    private int treasuresPicked;
    private float score;
    private bool gameRunning;
    private float stopTimer;

    public GameObject ball;
    private GameObject ballInit;
    public GameObject treasure;
    private GameObject treasureInit;
    private GameObject soundObject;
    private GameObject timeText;
    private GameObject treasureText;
    private GameObject scoreText;
    private GameObject player;

    void Start()
    {
        this.nextSpawn = 5f;
        spawnBall();
        spawnBall();
        spawnBall();
        this.timer = 0f;
        this.treasureInGame = false;
        this.treasuresPicked = 0;
        this.soundObject = GameObject.Find("soundObject");
        this.timeText = GameObject.Find("timeText");
        this.treasureText = GameObject.Find("treasureText");
        this.scoreText = GameObject.Find("scoreText");
        this.gameRunning = true;
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        timer += Time.deltaTime * 1f;
        if (gameRunning)
        {
            score = timer * (float)treasuresPicked;
            this.timeText.GetComponent<Text>().text = "Time: " + Math.Truncate(timer).ToString();
            this.treasureText.GetComponent<Text>().text = "Treasures: " + treasuresPicked.ToString();
            this.scoreText.GetComponent<Text>().text = "Score: " + Math.Truncate(score).ToString();

            if (Math.Truncate(timer) == nextSpawn)
            {
                spawnBall();
                nextSpawn = nextSpawn + 5f;
            }

            if (!treasureInGame)
            {
                spawnTreasure();
            }
        }
        if (!gameRunning && (timer - stopTimer > 3))
        {
            SceneManager.LoadScene(4);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void spawnBall()
    {
        ballInit = Instantiate(ball, new Vector3(UnityEngine.Random.Range(220f, 460f), 10f, UnityEngine.Random.Range(310f, 560f)), Quaternion.identity);
    }

    void spawnTreasure()
    {
        ballInit = Instantiate(treasure, new Vector3(UnityEngine.Random.Range(220f, 460f), 10f, UnityEngine.Random.Range(310f, 560f)), Quaternion.identity);
        treasureInGame = true;
    }

    public void pickupTreasure()
    {
        soundObject.GetComponents<AudioSource>()[0].Play();
        treasuresPicked++;
        treasureInGame = false;
    }

    public void stopGame()
    {
        gameRunning = false;
        GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
        foreach (GameObject ball in balls)
        {
            ball.GetComponent<Rigidbody>().isKinematic = true;
        }
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<ThirdPersonUserControl>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        GameObject.FindGameObjectWithTag("treasure").GetComponent<Rigidbody>().isKinematic = true;
        soundObject.GetComponents<AudioSource>()[1].Stop();
        soundObject.GetComponents<AudioSource>()[2].Play();
        stopTimer = timer;
        PlayerPrefs.SetInt("score", (int)score);
        PlayerPrefs.SetInt("game", 1);
    }
}
