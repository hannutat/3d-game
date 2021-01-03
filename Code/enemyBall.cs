using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyBall : MonoBehaviour
{
    private GameObject target;
    public bool attacking;

    void Start()
    {
        this.attacking = false;
        this.target = GameObject.Find("RollerBall");
    }

    void Update()
    {
        if (attacking)
        {
            this.GetComponent<NavMeshAgent>().SetDestination(this.target.GetComponent<Transform>().position);
        }
    }
}
