using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterTrigger : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "RollerBall")
        {
            GameObject.Find("soundObject").GetComponents<AudioSource>()[0].Stop();
            GameObject.Find("soundObject").GetComponents<AudioSource>()[1].Play();
            GameObject.Find("gameCode").GetComponent<game2>().stopGame();
        }
    }
}
