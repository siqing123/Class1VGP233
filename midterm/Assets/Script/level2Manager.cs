using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level2Manager : MonoBehaviour
{
    [SerializeField]
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
        if (UI.Instance != null && count > 5)
        {
            UI.Instance.ChangeScene();
        }
    }
    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
