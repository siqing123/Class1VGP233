using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifeSpan = 5.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            other.gameObject.SetActive(false);

        }
    }
    void Update()
    {

        if (lifeSpan > 0.0f)
        {
            lifeSpan -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
