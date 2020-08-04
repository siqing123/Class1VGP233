using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviourSingletonPersistent<UI>
{
    public int CurrentSceneNumber;

    void Awake()
    {
        CurrentSceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
    public void ChangeScene()
    {
        if (CurrentSceneNumber < 2)
        {
            SceneManager.LoadScene(CurrentSceneNumber + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
