using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourSingletonPersistent<T> : MonoBehaviourSingleton<T>
    where T : Component
{
    public override void Awake()
    {
        if (Instance == this)
        {
            DontDestroyOnLoad(this);
        }
        base.Awake();
    }
}
