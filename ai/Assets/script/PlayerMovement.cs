using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;
    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    private float shootForce = 10.0f;
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray,out hitInfo,100,whatCanBeClickedOn))
            {
                myAgent.SetDestination(hitInfo.point);
            }
        }
        Shoot();
    }

    void Shoot()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Rigidbody b = Instantiate(bullet, muzzle.position, muzzle.rotation) as Rigidbody;
            b.AddForce(muzzle.forward * shootForce);
        }
    }
}
