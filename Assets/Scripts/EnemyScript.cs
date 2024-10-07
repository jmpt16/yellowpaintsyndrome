using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    public Transform test;
    // Start is called before the first frame update
    void Start()
    {
        target= GameObject.FindFirstObjectByType<PlayerScript>().transform;
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Linecast(transform.position,target.transform.position, out hit) && hit.transform==target.transform)
        {
            agent.destination = target.position;
        }
        //test.position = agent.destination;
    }
}
