using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_navmesh_agent_script : MonoBehaviour
{
    public Transform target;
    UnityEngine.AI.NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
