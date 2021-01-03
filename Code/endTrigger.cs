using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endTrigger : MonoBehaviour
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
            GameObject.Find("gameCode").GetComponent<game2>().completed = true;
            GameObject.Find("gameCode").GetComponent<game2>().stopGame();
        }
    }
}
