using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowDastination : MonoBehaviour
{
    private NavMeshAgent agent = null;
    public Transform destinaton = null;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destinaton.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
