using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure : MonoBehaviour
{

    private GameObject codeObject;

    void Start()
    {
        this.codeObject = GameObject.Find("codeObject");
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            this.codeObject.GetComponent<game>().pickupTreasure();
            Destroy(gameObject);
        }
    }
}
