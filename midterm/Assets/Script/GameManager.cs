using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourSingletonPersistent<GameManager>
{
    [SerializeField]

    public bool Loadgame = false;
    public int count;
    public Text countText;
    void Awake()
    {
        count = 0;
        SetCountText();
    }

    public void addCount()
    {
        count += 1;
    }
    public void ChangeScene()
    {
        if (UI.Instance.CurrentSceneNumber == 1 && UI.Instance != null && count>5)
        {
            UI.Instance.ChangeScene();
        }

        if (UI.Instance.CurrentSceneNumber == 2 && UI.Instance != null && count > 6)
        {
            UI.Instance.ChangeScene();
        }
    }
    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}

