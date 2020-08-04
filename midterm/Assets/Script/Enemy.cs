using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private float alerRadius = 3.0f;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Transform[] patrolNodes;
    private int currentPatrolNodeIndex = 0;

    [SerializeField]
    private float startingTime = 1.0f;
    private float stoppingTime;

    [SerializeField]
    private float distanceFromPatrolNode = 2.0f;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(patrolNodes[currentPatrolNodeIndex].position);
        stoppingTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, patrolNodes[currentPatrolNodeIndex].position);
        if (!agent.pathPending && agent.remainingDistance < distanceFromPatrolNode)
        {
            if (stoppingTime > 0.0f)
            {
                stoppingTime -= Time.deltaTime;
            }
            else
            {
                UpdatePatrolNodeIndex();
                stoppingTime = startingTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
       // Gizmos.color = Color.red;
       // Gizmos.DrawWireSphere(transform.position, alerRadius);
       // Gizmos.DrawLine(transform.position, patrolNodes[currentPatrolNodeIndex].position);
    }

    private void PersuePlayer()
    {
        if (Vector3.SqrMagnitude(target.transform.position - transform.position) <= alerRadius * alerRadius)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    private void UpdatePatrolNodeIndex()
    {
        currentPatrolNodeIndex = (currentPatrolNodeIndex + 1) % patrolNodes.Length;
        agent.SetDestination(patrolNodes[currentPatrolNodeIndex].position);
    }
    public float getPatrolNodeDistance()
    {
        return distanceFromPatrolNode;
    }
}
