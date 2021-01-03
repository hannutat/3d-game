using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody ballBody;
    private Vector3 curTorque;
    private bool move;
    private bool inArea;
    private bool inverted;

    void Start()
    {
        this.curTorque = getRandomTorque();
        this.inArea = true;
        this.inverted = false;
    }

    
    void Update()
    {
        if (!inArea && !inverted)
        {
            Vector3 velo = this.GetComponent<Rigidbody>().velocity;
            Vector3 inverse = new Vector3(-velo.x * 50, -velo.y * 50, -velo.z * 50);
            this.GetComponent<Rigidbody>().AddForce(inverse);
            inverted = true;
            this.curTorque = getRandomTorque();
        }
        
        this.GetComponent<Rigidbody>().AddTorque(curTorque);

        if (this.GetComponent<Transform>().position.x < 190 || this.GetComponent<Transform>().position.x > 480)
        {
            inArea = false;
        }

        if (this.GetComponent<Transform>().position.z < 300 || this.GetComponent<Transform>().position.z > 580)
        {
            inArea = false;
        }

        if (this.GetComponent<Transform>().position.y > 29)
        {
            inArea = false;
        }

        if (this.GetComponent<Transform>().position.x > 190 && this.GetComponent<Transform>().position.x < 480 &&
            this.GetComponent<Transform>().position.z > 300 && this.GetComponent<Transform>().position.z < 580 &&
            this.GetComponent<Transform>().position.y < 29)
        {
            inArea = true;
            inverted = false;
        }
    }

    private Vector3 getRandomTorque()
    {
        Vector3 vec3 = new Vector3();
        vec3.x = Random.Range(-1000f, 1000f);
        vec3.y = Random.Range(-1000f, 1000f);
        vec3.z = Random.Range(-1000f, 1000f);
        return vec3;
        
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ball")
        {
            int soundToPlay = Random.Range(0, 2);
            this.GetComponents<AudioSource>()[soundToPlay].Play();
        }

        if (collision.collider.tag == "Player")
        {
            GameObject.Find("codeObject").GetComponent<game>().stopGame();
        }
    }
    
}
