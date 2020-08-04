using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed = 5;

    public GameObject go;

    [SerializeField]
    private Transform muzzle;
    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    private float shootForce = 10.0f;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.Q))
        {

            go.transform.Rotate(0, -60 * Time.deltaTime* movespeed, 0, Space.Self);

        }
        if (Input.GetKey(KeyCode.E))
        {

            go.transform.Rotate(0, 60* Time.deltaTime* movespeed, 0, Space.Self);

        }

        if (Input.GetKey(KeyCode.W))

        {

            go.transform.Translate(0, 0, movespeed * Time.deltaTime, Space.World);

        }

        if (Input.GetKey(KeyCode.S))

        {

            go.transform.Translate(0, 0, movespeed * Time.deltaTime * (-1), Space.World);

        }

        if (Input.GetKey(KeyCode.A))

        {

            go.transform.Translate(movespeed * Time.deltaTime * (-1), 0, 0, Space.World);

        }

        if (Input.GetKey(KeyCode.D))

        {

            go.transform.Translate(movespeed * Time.deltaTime, 0, 0, Space.World);

        }
    }
    void Shoot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Rigidbody b = Instantiate(bullet, muzzle.position, muzzle.rotation) as Rigidbody;
            b.AddForce(muzzle.forward * shootForce);
        }
    }
}
