using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballTrigger : MonoBehaviour
{


    void Start()
    {

    }


    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "titleBall")
        {
            GameObject.Find("Main Camera").GetComponent<intro>().move = false;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
        }
    }
}
