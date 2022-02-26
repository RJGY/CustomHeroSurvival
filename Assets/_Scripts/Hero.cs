using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hero : Entity
{
    // Objects
    private Player player;
    private NavMeshAgent agent;

    // Stats
    private int lives;
    private float luck;

    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
    }

    void GetComponentsOnStart()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
