using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class port1 : MonoBehaviour
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
            if (GameObject.Find("enemyBall").GetComponent<enemyBall>().attacking)
            {
                GameObject.Find("enemyBall").GetComponent<enemyBall>().attacking = false;
                GameObject.Find("gameCode").GetComponent<game2>().warning = false;
            }
            else if (!GameObject.Find("enemyBall").GetComponent<enemyBall>().attacking)
            {
                GameObject.Find("enemyBall").GetComponent<enemyBall>().attacking = true;
                GameObject.Find("gameCode").GetComponent<game2>().warning = true;
            }
        }
    }
}
