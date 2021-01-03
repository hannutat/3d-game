using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private GameObject gameCode;
    
    void Start()
    {
        this.gameCode = GameObject.Find("gameCode");
    }

    
    void Update()
    {
        if (this.GetComponent<Transform>().position.y < 10.5f)
        {
            this.gameCode.GetComponent<game2>().arrowFalling = false;
            Destroy(gameObject);
        }
    }
}
