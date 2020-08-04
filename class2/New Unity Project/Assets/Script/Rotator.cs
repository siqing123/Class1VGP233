using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(transform.up, 50 * Time.deltaTime);
    }
}
