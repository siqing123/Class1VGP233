using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet :MonoBehaviour

{
    public int count = 0;
    private float lifeSpan = 5.0f;

   // void OnTriggerEnter(Collider other)
   // {
   //     if (other.gameObject.CompareTag("wood"))
   //     {
   //         other.gameObject.SetActive(false);
   //         UI.Instance.ChangeScene();
   //     }
   // }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("wood"))
        {
            other.gameObject.SetActive(false);
            //UI.Instance.ChangeScene();
        }

       

        if (other.gameObject.CompareTag("enemy"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.addCount();
            GameManager.Instance.SetCountText();
            GameManager.Instance.ChangeScene();
            //UI.Instance.ChangeScene();
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
