using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : Singleton<MySceneManager>
{
    List<AsyncOperation> sceneLoadingList = new List<AsyncOperation>();

    //public Action SystemSceneCallback;
    public enum SceneIndex
    {
        SystemScene,
        LoadingScene,
        LoginScene,
        LobbyScene,
        StartScene,
        PickHeroScene,
        GamePlayScene,
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LoadScene(SceneIndex sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex.ToString());
    }

    public void LoadSystemSceneAsync(Action SystemSceneCallback)
    {
        //SceneManager.LoadSceneAsync(SceneIndex.SystemScene.ToString(), LoadSceneMode.Additive);
        StartCoroutine(LoadSystemScene(SystemSceneCallback));
    }
    
    public IEnumerator LoadSystemScene(Action systemSceneCallback)
    {
        AsyncOperation asyncOperation = 
            SceneManager.LoadSceneAsync(SceneIndex.SystemScene.ToString(), LoadSceneMode.Additive); ;
        
        while (!asyncOperation.isDone)
        {
            yield return null;

        }


        Scene targetScene = SceneManager.GetSceneByName(MySceneManager.SceneIndex.SystemScene.ToString());
        SceneManager.MoveGameObjectToScene(this.gameObject, targetScene);
        systemSceneCallback?.Invoke();

    }

    public void LoadingSceneAsync(SceneIndex sceneIndex)
    {

        //SceneManager.LoadSceneAsync(sceneIndex.ToString(), LoadSceneMode.Additive);

        StartCoroutine(LoadingSceneAsyncCallback(sceneIndex));

    }

    public IEnumerator LoadingSceneAsyncCallback(SceneIndex sceneIndex)
    {
        //LoadNewScene
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex.ToString(), LoadSceneMode.Additive);

        Debug.Log("Load Scene " + sceneIndex.ToString());
        while (!asyncOperation.isDone)
        {
            yield return null;

        }
       

        //Just keep newScene and system scene
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene tmp = SceneManager.GetSceneAt(i);

            //UnLoadScene(tmp.name);

            if ((tmp.name != SceneIndex.SystemScene.ToString()) && tmp.name != sceneIndex.ToString())
            {
                Debug.Log("Scene name : " + tmp.name);

                UnLoadScene(tmp.name);
            }
        }

        //Change active scene
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneIndex.ToString()));
        Debug.Log("Active scene is " + SceneManager.GetActiveScene().name);
    }

    public void UnLoadScene(SceneIndex sceneIndex)
    {
        SceneManager.UnloadSceneAsync(sceneIndex.ToString());

    }
    public void UnLoadScene(string sceneName)
    {
        Debug.Log("Unload scene" + sceneName);
        SceneManager.UnloadSceneAsync(sceneName);

    }


    public void SwitchSceneAsync(SceneIndex sceneIndex)
    {
        //loadingSceen.SetActive(true);

        //StartCoroutine(LoadingProgress(sceneIndex));
        //SceneManager.UnloadSceneAsync((int)currentScene);

    }




}
