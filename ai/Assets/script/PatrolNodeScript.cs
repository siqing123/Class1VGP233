using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNodeScript : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, enemy.getPatrolNodeDistance());
    }
}
