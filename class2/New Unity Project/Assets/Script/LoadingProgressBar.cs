using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    public Image loadingBarImage;
    private void Awake()
    {
        loadingBarImage.fillAmount = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        float progress = Mathf.Clamp01(Loader.GetLoadingProgress() / 0.9f);
        loadingBarImage.fillAmount = progress;
    }
}
