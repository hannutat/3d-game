using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    public bool move;
    private GameObject helpText;
    private GameObject ball;

    void Start()
    {
        this.helpText = GameObject.Find("helpText");
        this.ball = GameObject.Find("titleBall");
        this.move = true;
    }
    
    void Update()
    {

        if (!move)
        {
            this.helpText.GetComponent<Text>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }

        if (move)
        {
            this.ball.GetComponent<Transform>().Translate(new Vector3(0f, 0f, -0.5f));
            this.ball.GetComponent<Transform>().Rotate(new Vector3(0f, 0f, 3.5f));
        }
    }
}
