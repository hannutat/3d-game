using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCamera : MonoBehaviour
{
    private GameObject ball;
    private Vector3 camVector;

    void Start()
    {
        this.ball = GameObject.Find("RollerBall");
    }

    
    void Update()
    {
        camVector = ball.GetComponent<Transform>().position;
        camVector.y = camVector.y + 5f;
        camVector.z = camVector.z - 10f;
        this.gameObject.GetComponent<Transform>().position = camVector;
    }
}
