using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    private class LoadingMomobehavior : MonoBehaviour { }
    public enum Scene
    {
        GameScene,
        LoadingScene,
        MainMenu,
    }

    private static Action onLoaderCallback;
    private static AsyncOperation loadingAsyncOperation;
    internal static void Load(Scene scene)
    {
        onLoaderCallback = () =>
        {
            GameObject LoadingGameObject = new GameObject("Loading Game Object");
            LoadingGameObject.AddComponent<LoadingMomobehavior>().StartCoroutine(LoadSceneAsync(scene));
        };

        SceneManager.LoadScene(Loader.Scene.LoadingScene.ToString());
    }


    public static float GetLoadingProgress()
    {
        if(loadingAsyncOperation!=null)
        {
            return loadingAsyncOperation.progress;
        }
        return 0.0f;
    }

}
